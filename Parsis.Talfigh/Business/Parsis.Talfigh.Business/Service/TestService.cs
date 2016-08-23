using Parsis.Talfigh.Business.Model;
using Parsis.Talfigh.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.Business.Service
{

    public interface ITestService
    {
        Task<List<TestModel>> Get();
        Task<long> Insert(TestModel model);
        Task<long> Update(TestModel model);
        Task<bool> Delete(long id);
    }
    public class TestService : ITestService
    {

        private IUnitOfWork _uow;
        public TestService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Delete(long id)
        {
           return  await _uow.TestRepository.DeleteAsync(id) > 0;
        }

        public async Task<List<TestModel>> Get()
        {
            var result = await _uow.TestRepository.GetAllAsync();
            return result.Select(x => new TestModel() { Code = x.Code, Id = x.Id, Title = x.Title }).ToList();
        }

        public async Task<long> Insert(TestModel model)
        {
            return await _uow.TestRepository.InsertAsync(new DAL.Domain.Base.Test() { Code = model.Code, Title = model.Title });
        }

        public async Task<long> Update(TestModel model)
        {
            return await _uow.TestRepository.UpdateAsync(new DAL.Domain.Base.Test() { Code = model.Code, Title = model.Title ,Id = model.Id});
        }
    }
}
