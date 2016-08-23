using Parsis.Talfigh.Business.Service;
using Parsis.Talfigh.DAL.Domain.Base;
using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.Service.ServiceInterface;
using Parsis.Talfigh.Service.ServiceModel;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.OrmLite;
using ServiceStack.Web;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using Parsis.Talfigh.Service.ServiceModel.Model;

namespace Parsis.Talfigh.Service.ServiceInterface
{
    public class TestsAuthenticateService : ServiceStack.Service
    {

        [Authenticate]
        public async Task<object> Get(TestsAuthenticateRequest request)
        {

            return new TestsResponse();
        }
       
    }

}
