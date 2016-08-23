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
    public class UserSessionRepository : LiteRepositoryBase<UserSession>, IUserSessionRepository
    {

        public UserSessionRepository(IDbConnectionFactory dbFactory)
         : base(dbFactory) { }


       
        public UserSession GetLatestByUserId(long userId)
        {
            using (var db = dbFactory.Open())

            {
                var exp = db.From<UserSession>()
                        .Limit(0, 1)
                        .OrderByDescending<UserSession>(p => p.Id).Where(c => c.UserId == userId);

                return  db.Single<UserSession>(exp);
            }


        }
    }

    public interface IUserSessionRepository : ILiteRepository<UserSession>
    {
        UserSession GetLatestByUserId(long userId);
    }
}
