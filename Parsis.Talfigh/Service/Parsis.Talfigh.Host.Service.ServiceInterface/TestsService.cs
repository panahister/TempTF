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
using Parsis.Talfigh.Infra.Security;
using ServiceStack.FluentValidation;

namespace Parsis.Talfigh.Service.ServiceInterface
{
    public class TestsService : ServiceStack.Service
    {
        private ITestService _testService;
      

        public TestsService(ITestService testService)
        {
            _testService = testService;
         
        }

        [Authenticate]
        [RequiredPermission("GetTest")]
        public async Task<object> Get(TestsRequest request)
        {
            var result = await _testService.Get();

            return new TestsResponse { Tests = result.Select(x => new TestsModel() { code = x.Code, id = x.Id, title = x.Title }).ToList() };
        }
        // [SSLRequierdttribute]
        public async Task<object> Post(TestsRequest request)
        {
       

            return await _testService.Insert(new Business.Model.TestModel() { Code = request.code, Title = request.title });
        }
        public async Task<object> Put(TestsRequest request)
        {
            return await _testService.Update(new Business.Model.TestModel() { Code = request.title, Title = request.title, Id = request.id });
        }

        [GuestAttribute]
        public async Task<object> Delete(TestsRequest request)
        {
            await _testService.Delete(request.id);

            return new TestsResponse();

        }
      

    }

}
