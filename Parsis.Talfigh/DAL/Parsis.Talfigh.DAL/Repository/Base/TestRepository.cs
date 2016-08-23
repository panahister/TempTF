using Parsis.Talfigh.DAL.Domain.Base;
using Parsis.Talfigh.DAL.Infrastructure;
using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;



namespace Parsis.Talfigh.DAL.Repository.Base
{
    public class TestRepository : LiteRepositoryBase<Test>, ITestRepository
    {

        public TestRepository(IDbConnectionFactory dbFactory)
         : base(dbFactory) { }

     

        public async Task<List<Test>> GetByCode(string code)
        {


            using (var db = dbFactory.Open())
            {
                return await db.SelectAsync<Test>(db.From<Test>().Where(c => c.Code == code));
            }

        }

    }

    public interface ITestRepository : ILiteRepository<Test>
    {
      Task<List<Test>> GetByCode(string code);
    }
}
