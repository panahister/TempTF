using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Zoraq.CommonModel.Enum;
using Zoraq.Infra.Validation;

namespace Parsis.Talfigh.Service.ServiceModel.Models.Security
{
    public class signUp

    {

        [Required]
        public string password
        {
            get;
            set;
        }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string mobile { get; set; }

        [Required]
        public Gender genderType { get; set; }

     
    }
}