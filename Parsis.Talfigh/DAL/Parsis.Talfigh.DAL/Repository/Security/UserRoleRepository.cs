using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.DAL.Domain.Security;

namespace Parsis.Talfigh.DAL.Repository.Security
{
    public class UserRoleRepository : LiteRepositoryBase<UserRole>, IUserRoleRepository
    {

        public UserRoleRepository(IDbConnectionFactory dbFactory)
         : base(dbFactory) { }


        


    }

    public interface IUserRoleRepository : ILiteRepository<UserRole>
    {

    }
}
