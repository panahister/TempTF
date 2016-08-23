using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.DAL.Domain.Security;
using ServiceStack.Data;

namespace Parsis.Talfigh.DAL.Repository.Security
{
    public class RoleRepository : LiteRepositoryBase<Role>, IRoleRepository
    {

        public RoleRepository(IDbConnectionFactory dbFactory)
         : base(dbFactory) { }

        public async Task<Role>  GetDefaultRole()
        {
            using (var db = dbFactory.Open())

            {
                var tasks = await db.SelectAsync<Role>(c => c.IsDefault);
                return tasks.FirstOrDefault();
            }
           
        }

        public List<Role> GetUserRoleSync(long userId)
        {
            using (var db = dbFactory.Open())

            {

                var q = db.From<Role>()
                    
                     .Join<Role, UserRole>()
                     .Join<UserRole, User>((ur, u) => u.Id == userId)
                     .SelectDistinct();

                return db.Select<Role>(q);
            }

        }

    }

    public interface IRoleRepository : ILiteRepository<Role>
    {
        Task<Role> GetDefaultRole();
        List<Role> GetUserRoleSync(long userId);
    }
}
