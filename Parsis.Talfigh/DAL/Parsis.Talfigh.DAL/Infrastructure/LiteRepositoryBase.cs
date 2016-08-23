using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Configuration;
using ServiceStack.Data;

namespace Parsis.Talfigh.DAL.Infrastructure
{
    public class LiteRepositoryBase<T> : IDisposable, ILiteRepository<T> where T : class
    {
        protected IDbConnectionFactory dbFactory;

     

        public LiteRepositoryBase(IDbConnectionFactory dbFactory)
        {
            this.dbFactory = dbFactory;

        }

        public virtual List<T> GetAll()
        {
            using (var db = dbFactory.Open())
            {
                return db.Select<T>();
            }

        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            using (var db = dbFactory.Open())
            {
                return await db.SelectAsync<T>();
            }

        }

        public List<T> Get(Expression<Func<T, bool>> exp)
        {

            using (var db = dbFactory.Open())
            {

                return db.Select<T>(exp);
            }
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> exp)
        {

            using (var db = dbFactory.Open())
            {

                return await db.SelectAsync<T>(exp);
            }
        }

        public virtual T GetById(long id)
        {
            using (var db = dbFactory.Open())
            {

                return db.SingleById<T>(id);
                 
            }
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            using (var db = dbFactory.Open())
            {

                return await db.SingleByIdAsync<T>(id);
            }
        }

        public bool Save(T o, bool references)
        {


            using (var db = dbFactory.Open())
            {

                return db.Save<T>(o);
            }
           

        }

        public async Task<bool> SaveAsync(T o, bool references)
        {
           

            using (var db = dbFactory.Open())
            {

                return await db.SaveAsync<T>(o, references);
            }


        }

        public int Delete(long id)
        {

            using (var db = dbFactory.Open())
            {
              return   db.DeleteById<T>(id);
            }


        }

        public async Task<int> DeleteAsync(long id)
        {
            using (var db = dbFactory.Open())
            {
              return await  db.DeleteByIdAsync<T>(id);
            }
        }

        public int Delete(Expression<Func<T, bool>> exp)
        {
            using (var db = dbFactory.Open())
            {
              return   db.Delete<T>(exp);
            }
        }

        public async Task<int> DeleteAsync(Expression<Func<T, bool>> exp)
        {
            using (var db = dbFactory.Open())
            {
                return await db.DeleteAsync<T>(exp);
            }
        }

        public long Insert(T o)
        {
            using (var db = dbFactory.Open())
            {

                return db.Insert(o, selectIdentity: true);
            }

        }

        public long Update(T o)
        {
            using (var db = dbFactory.Open())
            {

                return db.Update(o);
            }
        }

        public async Task<long> InsertAsync(T o)
        {
            using (var db = dbFactory.Open())
            {

                return await db.InsertAsync(o, selectIdentity: true);
            }
        }

        public async Task<long> UpdateAsync(T o)
        {

            using (var db = dbFactory.Open())
            {

                return await db.UpdateAsync(o);
            }
        }

        public void Dispose()
        {
           
            
        }

        
    }
}
