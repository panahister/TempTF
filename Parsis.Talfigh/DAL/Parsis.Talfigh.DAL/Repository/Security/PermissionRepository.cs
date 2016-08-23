using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.DAL.Domain.Security;
using ServiceStack.OrmLite;
using ServiceStack.Data;

namespace Parsis.Talfigh.DAL.Repository.Security
{
    public class PermissionRepository : LiteRepositoryBase<Permission>, IPermissionRepository
    {

        public PermissionRepository(IDbConnectionFactory dbFactory)
         : base(dbFactory) { }

        public async Task <List<Resource>> GetUserPermission(long userId)
        {
            using (var db = dbFactory.Open())

            {

                var q = db.From<Resource>()
                     .Join<Resource, Permission>()
                     .Join<Permission, Role>()
                     .Join<Role, UserRole>()
                     .Join<UserRole, User>((ur, u) => u.Id == userId)
                     .SelectDistinct();

                return await db.SelectAsync<Resource>(q);
            }

        }

        public List<Resource> GetUserPermissionSync(long userId)
        {
            using (var db = dbFactory.Open())

            {

                var q = db.From<Resource>()
                     .Join<Resource, Permission>()
                     .Join<Permission, Role>()
                     .Join<Role, UserRole>()
                     .Join<UserRole, User>((ur, u) => u.Id == userId)
                     .SelectDistinct();

                return  db.Select<Resource>(q);
            }

        }

    }

    public interface IPermissionRepository : ILiteRepository<Permission>
    {
       Task<List<Resource>> GetUserPermission(long userId);
        List<Resource> GetUserPermissionSync(long userId);
    }
}
