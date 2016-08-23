using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Parsis.Talfigh.Security.Helper;
using busModel = Parsis.Talfigh.Security.Models;
using dalModel = Parsis.Talfigh.DAL.Domain.Security;
using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.Infra.Exception;
using ServiceStack.Auth;
using Parsis.Talfigh.Security.Model;

namespace Parsis.Talfigh.Security.Service
{
    public interface IUserService
    {

        Task<bool> SignUp(busModel.User model);
        bool SignInSync(busModel.Login model);
        Task<bool> IsEmailExist(string email);
        Task<bool> ForgetPassword(busModel.ForgetPassword model);
        busModel.Identity SetAndGetUserIdentity(IAuthSession session);

    }
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private  IUserIdentity _userIdentity;
        private  IUserHelper _userHelper;

        public UserService(IUnitOfWork liteUnitOfWork, IUserHelper userHelper, IUserIdentity userIdentity)
        {
            this._unitOfWork = liteUnitOfWork;

            this._userHelper = userHelper;

            this._userIdentity = userIdentity;
        }

        public async Task<bool> SignUp(busModel.User model)
        {

            try
            {

                if (!await _unitOfWork.UserRepository.CheckExistenceEmail(model.Email))
                {
                    busModel.UserLoggedInInfo loginOutput = new Parsis.Talfigh.Security.Models.UserLoggedInInfo();

                    TinyMapper.Bind<busModel.User, dalModel.User>(config =>
                    {
                        config.Ignore(x => x.Password);
                    });

                    var user = TinyMapper.Map<dalModel.User>(model);

                    user = await _userHelper.SetSignUpPolicy(user);

                    await _unitOfWork.UserRepository.SaveAsync(user, true);

                    MD5 Hash = MD5.Create();

                    user.Password = Hash.ComputeHash(Encoding.ASCII.GetBytes(model.Password + user.Id));

                    await _unitOfWork.UserRepository.UpdateAsync(user);

                    return true;//await SignIn(new busModel.Login() { Email = model.Email, Password = model.Password });
                }

                else

                    throw new ParsisException(ExceptionType.UserNameExist);
            }

            catch (Exception ex)
            {
                throw new ParsisException(ExceptionType.InternalServerError);
            }


        }

        public bool SignInSync(busModel.Login model)
        {
            var result = false;
            try
            {
                var dalUser = _unitOfWork.UserRepository.GetUserByEmailSync(model.Email);

                TinyMapper.Bind<dalModel.User, busModel.User>();

                var user = TinyMapper.Map<busModel.User>(dalUser);

                if (user == null)
                    throw new ParsisException(ExceptionType.InternalServerError);




                MD5 Hash = MD5.Create();

                var password = Hash.ComputeHash(Encoding.ASCII.GetBytes(model.Password + user.Id));

                if (_unitOfWork.UserRepository.SignInSync(model.Email, password))
                {
                    if (dalUser.Status == Parsis.Talfigh.DAL.Domain.Enum.EntityStatus.InActive)
                        throw new ParsisException(ExceptionType.InActive);

                    result = true;

                }
                else
                    throw new ParsisException(ExceptionType.InvalidUserNameOrPassword);

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public busModel.Identity SetAndGetUserIdentity(IAuthSession session)
        {
            var identity = GetUserIdentitySync(session.UserAuthName);

            //_unitOfWork.UserSessionRepository.Insert(new DAL.Domain.Security.UserSession()
            //{
            //    ExpireDateTime = DateTime.Now.AddMinutes(20),
            //    Session = session.Id,
            //    SignInDateTime = DateTime.Now,
            //    SignOutDateTime = DateTime.Now,
            //    Status = DAL.Domain.Enum.EntityStatus.Active,
            //    UserId = identity.User.Id,
            //});

            return identity;


          

        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _unitOfWork.UserRepository.CheckExistenceEmail(email);
        }

        public async Task<bool> ForgetPassword(busModel.ForgetPassword model)
        {
            if (await IsEmailExist(model.Email))
            {
                var dalUser = await _unitOfWork.UserRepository.GetUserByEmail(model.Email);

                MD5 Hash = MD5.Create();

                dalUser.Password = Hash.ComputeHash(Encoding.ASCII.GetBytes(model.NewPassword + dalUser.Id));

                await _unitOfWork.UserRepository.UpdateAsync(dalUser);

                return true;

            }
            else
                throw new ParsisException(ExceptionType.UserNameDoesNotExist);
        }


        private busModel.Identity GetUserIdentitySync(string userName)
        {
            busModel.Identity model = new busModel.Identity();

            var dalUser = _unitOfWork.UserRepository.GetUserByEmailSync(userName);

            var dalResult = _unitOfWork.PermissionRepository.GetUserPermissionSync(dalUser.Id);

            model.User = new Models.User()
            {
                Email = dalUser.Email,
                FirstName = dalUser.FirstName,
                GenderType = (CommonModel.Enum.Gender)dalUser.GenderType,
                LastName = dalUser.LastName

            };

            model.Permissions = dalResult.Where(c => !c.IsMenu).Select(a => new busModel.Permission() { description = a.Description, key = a.Key, value = a.Value }).ToList();

            model.DashboardMenus = dalResult.Where(c => c.IsMenu).Select(a => new busModel.DashboardMenu() { description = a.Description, key = a.Key, value = a.Value, id = a.Id, parentId = a.ParentId }).ToList();

            TinyMapper.Bind<List<dalModel.Role>, List<busModel.Role>>();

            model.Roles = TinyMapper.Map<List<busModel.Role>>(_unitOfWork.RoleRepository.GetUserRoleSync(dalUser.Id));

            return model;


        }

        private async Task<busModel.Identity> GetUserIdentity(busModel.User user)
        {
            busModel.Identity model = new busModel.Identity();

            model.User = user;

            var dalResult = await _unitOfWork.PermissionRepository.GetUserPermission(user.Id);

            model.Permissions = dalResult.Where(c => !c.IsMenu).Select(a => new busModel.Permission() { description = a.Description, key = a.Key, value = a.Value }).ToList();

            model.DashboardMenus = dalResult.Where(c => c.IsMenu).Select(a => new busModel.DashboardMenu() { description = a.Description, key = a.Key, value = a.Value, id = a.Id, parentId = a.ParentId }).ToList();

            return model;


        }

    }

}
