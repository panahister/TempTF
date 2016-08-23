using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.DAL.Infrastructure
{
    public interface ILiteRepository<T> where T : class
    {
      
        List<T> GetAll();

        Task<List<T>> GetAllAsync();
      
        List<T> Get(Expression<Func<T, bool>> exp);

        Task<List<T>> GetAsync(Expression<Func<T, bool>> exp);
        T GetById(long id);

         Task<T> GetByIdAsync(long id);

        long Insert(T o);

        long Update(T o);

         Task<long> InsertAsync(T o);

        Task<long> UpdateAsync(T o);

      
        bool Save(T o, bool references);

        Task<bool> SaveAsync(T o,bool references);
       
        int Delete(long id);

        Task<int> DeleteAsync(long id);
       
        int Delete(Expression<Func<T, bool>> exp);

        Task<int> DeleteAsync(Expression<Func<T, bool>> exp);
    }
}
