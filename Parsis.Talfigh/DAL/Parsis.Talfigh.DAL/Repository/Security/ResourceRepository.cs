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
    public class ResourceRepository : LiteRepositoryBase<Resource>, IResourceRepository
    {

        public ResourceRepository(IDbConnectionFactory dbFactory)
         : base(dbFactory) { }

    }

    public interface IResourceRepository : ILiteRepository<Resource>
    {

    }
}
