using Parsis.Talfigh.DAL.Domain.Security;
using Parsis.Talfigh.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.Security.Helper
{
    public class UserHelper : IUserHelper
    {
        private readonly IUnitOfWork _liteUnitOfWork;

        public UserHelper(IUnitOfWork liteUnitOfWork)
        {
            _liteUnitOfWork = liteUnitOfWork;
        }
      

        public async Task<Parsis.Talfigh.DAL.Domain.Security.User> SetSignUpPolicy(Parsis.Talfigh.DAL.Domain.Security.User model)
        {
            model.Status = Parsis.Talfigh.DAL.Domain.Enum.EntityStatus.Active;

            model.CreateDateTime = DateTime.Now;

            model.Password = new byte[1];

            model.UserRoles = new List<Parsis.Talfigh.DAL.Domain.Security.UserRole>();

            var role = await _liteUnitOfWork.RoleRepository.GetDefaultRole();

            UserRole userRol = new Parsis.Talfigh.DAL.Domain.Security.UserRole();

            userRol.User = model;

            userRol.RoleId = role.Id;

            model.UserRoles.Add(userRol);

            return model;
        }
    }
    public interface IUserHelper
    {
        Task<Parsis.Talfigh.DAL.Domain.Security.User> SetSignUpPolicy(Parsis.Talfigh.DAL.Domain.Security.User model);
    }
}
