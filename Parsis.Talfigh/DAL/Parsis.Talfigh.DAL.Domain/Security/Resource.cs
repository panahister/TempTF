namespace Parsis.Talfigh.DAL.Domain.Security
{
    using ServiceStack.DataAnnotations;
    using System.Collections.Generic;

    [Schema("security")]
    public class Resource:Base.BaseEntity
	{
        public Resource() : base()
        {
        }

        public long? ParentId
        {
            get;
            set;
        }

        [StringLength(500)]
        [Required()]
        public  string Description
        {
			get;
			set;
		}

        [StringLength(50)]
        [Required()]
        public  string Key
		{
			get;
			set;
		}

        [StringLength(200)]
        [Required()]
        public  string Value
		{
			get;
			set;
		}

        
        [Required()]
        public bool IsMenu
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


        [Required()]
        public bool IsAnonymous
        {
            get;
            set;
        }


    }
}

