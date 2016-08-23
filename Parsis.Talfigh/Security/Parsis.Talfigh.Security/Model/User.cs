
using Parsis.Talfigh.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parsis.Talfigh.Security.Models
{
    public class User

    {
        public long Id { get; set; }

        [Required()]
        public string Password
        {
            get;
            set;
        }

        [Required]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }

        [Required]
        public Gender GenderType { get; set; }

        public DateTime? LastLoginRequest { get; set; }

        public DateTime? LastSuccessLogin { get; set; }

         public DateTime CreateDateTime { get; set; }

        public short UnsuccessTryCount { get; set; }

        [Required()]
        public EntityStatus Status
        {
            get;
            set;
        }
    }
}
