using Parsis.Talfigh.Security.Service.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.Security.Service.ServiceInterface
{
    public class SecurityServices : ServiceStack.Service
    {

        private IUserService _userService;


        public SecurityServices(IUserService userService)
        {
            _userService = userService;

        }

        public async Task<object> Post(SignUpRequest request)
        {

            return new SignUpResponse()
            {
                IsSuccess = await _userService.SignUp(new Models.User()

                {
                    Email = request.email,
                    FirstName = request.firstName,
                    GenderType = (CommonModel.Enum.Gender)request.gender,
                    LastName = request.lastName,
                    Mobile = request.mobile,
                    Password = request.password
                }

                    )

            };

        }

        public async Task<object> Get(SignUpRequest request)
        {


            //return await _userService.ForgetPassword(new Talfigh.Security.Models.ForgetPassword()
            //{
            //    Email = request.email,
            //    NewPassword = request.newPassword
            //});
            return new SignUpResponse();
        }

        public async Task<object> Put(SignUpRequest request)
        {
            return new SignUpResponse();
        }


        public async Task<object> Delete(SignUpRequest request)
        {
            return new SignUpResponse();

        }

    }
}
