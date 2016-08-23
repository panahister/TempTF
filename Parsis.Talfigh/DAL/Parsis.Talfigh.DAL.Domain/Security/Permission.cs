namespace Parsis.Talfigh.DAL.Domain.Security
{
    using ServiceStack.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [Schema("security")]
    public class Permission : Base.BaseEntity
	{

        public Permission() : base()
        {
        }

        [References(typeof(Role))]
        public long RoleId
        {
            get;
            set;
        }


        [Reference]
        public  Role Role
		{
			get;
			set;
		}

        [References(typeof(Resource))]
        public long ResourceId
        {
            get;
            set;
        }


        [Reference]
        public  Resource Resource
		{
			get;
			set;
		}

		

	}
}

