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
    public class UserRepository : LiteRepositoryBase<User>, IUserRepository
    {

        public UserRepository(IDbConnectionFactory dbFactory)
         : base(dbFactory) { }

        public async Task<bool> CheckExistenceEmail(string email)
        {
            using (var db = dbFactory.Open())
            {
                return (await db.CountAsync<User>(x => x.Email == email) > 0) ? true : false;
            }
        }
        public async Task<User> GetUserByEmail(string email)
        {
            using (var db = dbFactory.Open())

            {
                var userList = await db.SelectAsync<User>(x => x.Email == email);
                return userList.FirstOrDefault();
            }
        }

        public User GetUserByEmailSync(string email)
        {
            using (var db = dbFactory.Open())

            {
                var userList =  db.LoadSelect<User> (x => x.Email == email,include: new string[] { "UserRoles.Role" });
                return userList.FirstOrDefault();
            }
        }
        public async Task<bool> SignIn (string email, byte[] password)
        {
            using (var db = dbFactory.Open())

            {

                return (await db.CountAsync<User>(x => x.Email == email && x.Password == password) > 0) ? true : false;
            }
             
        }

        public bool SignInSync(string email, byte[] password)
        {
            using (var db = dbFactory.Open())

            {

                return ( db.Count<User>(x => x.Email == email && x.Password == password) > 0) ? true : false;
            }

        }

    }

    public interface IUserRepository : ILiteRepository<User>
    {
        Task<User> GetUserByEmail(string email);

        User GetUserByEmailSync(string email);

        Task<bool> CheckExistenceEmail(string email);
        Task<bool> SignIn(string email,byte[] password);
        bool SignInSync(string email, byte[] password);


    }
}
