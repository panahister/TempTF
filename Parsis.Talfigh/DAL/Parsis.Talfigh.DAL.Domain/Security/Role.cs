namespace Parsis.Talfigh.DAL.Domain.Security
{
    using Base;
    using Enum;
    using ServiceStack.DataAnnotations;
    using System.Collections.Generic;

    [Schema("security")]
    public class Role:Base.BaseEntity
	{
        public Role() : base()
        {
        }

        [StringLength(20)]
        [Required()]
        public  string Title
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

        [Reference]
        public List<UserRole> UserRoles
		{
			get;
			set;
		}

        [Reference]
        public List<Permission> Permissions
		{
			get;
			set;
		}

        public bool IsDefault { get; set; }
    }
}

