using ServiceStack;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Parsis.Talfigh.DAL.Domain.Base;
using System;
using Parsis.Talfigh.Service.ServiceModel.Model;

namespace Parsis.Talfigh.Service.ServiceModel.Models.Security//Parsis.Talfigh.Service.ServiceModel
{

    [Route("/ForgetPasswor", "POSt")]
    [Route("/ForgetPasswor", "GET")]
    public class ForgetPasswordRequest : IReturn<ForgetPasswordRequestResponse>
    {
        public string email { get; set; }

        public string newPassword { get; set; }

        public string newConfirmPassword { get; set; }
    }

    public class ForgetPasswordRequestResponse
    {
        public ForgetPasswordRequestResponse()
        {

        }
        public bool IsSuccess { get; set; }
    }

}