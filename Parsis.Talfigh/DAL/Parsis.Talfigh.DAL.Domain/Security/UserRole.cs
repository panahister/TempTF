
using ServiceStack.DataAnnotations;

namespace Parsis.Talfigh.DAL.Domain.Security
{
    [Schema("security")]
    public class UserRole:Base.BaseEntity
	{
        public UserRole():base()
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

	}
}

