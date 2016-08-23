using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace Parsis.Talfigh.Host.Assistant.Cache
{
    public abstract class RedisClientListBase<T> : IDisposable
    {

        private RedisEndpoint endPoint;
        public RedisClientListBase()
        {
            endPoint = ConnectionString.ToRedisEndpoint();
            endPoint.Db = (long)Db;
            Client = new RedisClient(endPoint);

            Redis = Client.As<T>();
        }


        protected virtual string ConnectionString { get; }

        protected virtual Redisdb Db { get; }

        protected RedisClient Client { get; set; }
        protected IRedisTypedClient<T> Redis { get; set; }

        public void Flushdb()
        {
            new RedisClient(endPoint).FlushDb();
        }
        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
