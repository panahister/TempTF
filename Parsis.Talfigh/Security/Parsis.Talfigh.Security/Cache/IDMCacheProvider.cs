using Parsis.Talfigh.Host.Assistant.Cache;
using Parsis.Talfigh.Infra.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parsis.Talfigh.Security.Cache
{
    public interface IIDMCacheProvider
    {

        void SetIdentity(string token, UserIdentity model, TimeSpan time, CacheProviderName provider = CacheProviderName.Redis);

        UserIdentity GetIdentity(string token, CacheProviderName provider = CacheProviderName.Redis);

        void RemoveIdentity(string token, CacheProviderName provider = CacheProviderName.Redis);


    }

    public class IDMCacheProvider : IIDMCacheProvider
    {
        private IIDMCacheFactory[] _factories;
        public IDMCacheProvider(IIDMCacheFactory[] factories)
        {
            _factories = factories;
        }

        public UserIdentity GetIdentity(string token, CacheProviderName provider = CacheProviderName.Redis)
        {
            return _factories.Where(c => c.Provider == provider).FirstOrDefault().GetIdentity(token);
        }

        public void RemoveIdentity(string token, CacheProviderName provider = CacheProviderName.Redis)
        {
            _factories.Where(c => c.Provider == provider).FirstOrDefault().RemoveIdentity(token);
        }

        public void SetIdentity(string token, UserIdentity model, TimeSpan time, CacheProviderName provider = CacheProviderName.Redis)
        {
            _factories.Where(c => c.Provider == provider).FirstOrDefault().SetIdentity(token, model, time);
        }
    }

}
