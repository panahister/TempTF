namespace Parsis.Talfigh.DAL.Domain.Security
{
    using Base;
    using Enum;
    using ServiceStack.DataAnnotations;
    using System;

    [Schema("security")]
    public class UserSession : Base.BaseEntity
	{
        public UserSession()
        {
           
        }


        [References(typeof(User))]
        public long UserId
        {
            get;
            set;
        }


        [Reference]
        public  User User
		{
			get;
			set;
		}

        [StringLength(100)]
        [Required()]
        public  string Session
		{
			get;
			set;
		}

        [Required()]
        public  DateTime SignInDateTime
        {
            get;
            set;
        }

        public DateTime SignOutDateTime
        {
            get;
            set;
        }

        [Required()]
        public  DateTime ExpireDateTime
		{
			get;
			set;
		}

        [Required()]
        [StringLength(15)]
        public EntityStatus Status
		{
			get;
			set;
		}

       

    }
}

