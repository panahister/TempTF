namespace Parsis.Talfigh.DAL.Domain.Security
{
    using Base;
    using Enum;
    using ServiceStack.DataAnnotations;
    using System;
    using System.Collections.Generic;

    [Schema("security")]
    public class User:Base.BaseEntity
	{
        public User():base()
        {
            Status = EntityStatus.InActive;
            CreateDateTime = DateTime.Now;
            LastSuccessLogin = DateTime.Now;
            LastLoginRequest = DateTime.Now;
        }


        [Required()]
        public  byte[] Password
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
        [StringLength(11)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(6)]
        public Gender GenderType { get; set; }

       
        public DateTime? LastLoginRequest { get; set; }

        public DateTime? LastSuccessLogin { get; set; }

        [Required()]
        public DateTime CreateDateTime
        {
            get;
            set;
        }

        public short UnsuccessTryCount { get; set; }


        [Required()]
        [StringLength(15)]
        public EntityStatus Status
		{
			get;
			set;
		}




        [StringLength(20)]
        public string LastIPConnection
        {
            get;
            set;
        }

        [Reference]
        public List<UserRole> UserRoles
		{
			get;
			set;
		}

        [Reference]
        public  List<UserSession> UserTokens
		{
			get;
			set;
		}

	}
}

