using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStack;
using Parsis.Talfigh.CommonModel.Enum;

namespace Parsis.Talfigh.Security.Service.ServiceModel
{
    
    [Route("/SignUp", "POST")]
    public class SignUpRequest : IReturn<SignUpResponse>
    {

        public string password
        {
            get;
            set;
        }

     
        public string email { get; set; }

       
        public string firstName { get; set; }

     
        public string lastName { get; set; }

       
        public string mobile { get; set; }

       
        public Gender gender { get; set; }
       
    }


    public class SignUpResponse
    {
        
        public bool IsSuccess { get; set; }
    }
}