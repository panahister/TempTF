using Parsis.Talfigh.Host.Assistant.Cache;
using Parsis.Talfigh.Infra.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parsis.Talfigh.Security.Cache
{
    public interface IIDMCacheFactory
    {
        CacheProviderName Provider { get; }
        void SetIdentity(string token, UserIdentity model, TimeSpan time);

        UserIdentity GetIdentity(string token);

        void RemoveIdentity(string token);


    }
    public class IDMRedisCachefactory : RedisClientListBase<UserIdentity>, IIDMCacheFactory
    {
        public CacheProviderName Provider
        {
            get
            {
                return CacheProviderName.Redis;
            }
        }


        protected override string ConnectionString
        {
            get
            {

                var settingsReader = new AppSettingsReader();
                string cnn = settingsReader.GetValue("IDMCacheConnectionString", typeof(string)).ToString();
                return cnn;
            }

        }


        protected override Redisdb Db
        {
            get
            {
                return Redisdb.UserToken;
            }
        }

        public IDMRedisCachefactory() : base()
        {
        }

        public void SetIdentity(string token, UserIdentity model, TimeSpan time)
        {
            RemoveIdentity(token);
            Redis.SetValue(token, model, time);
        }

        public UserIdentity GetIdentity(string token)
        {

            return Redis.GetValue(token);
        }

        public void RemoveIdentity(string token)
        {
            Redis.RemoveEntry(token);

        }

        public void Flusgdb()
        {
            Redis.FlushAll();
        }
    }

}
