using ServiceStack;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Parsis.Talfigh.Infra.Security
{
    public class UserIdentity : ServiceStack.Service
    {

        private static UserIdentity instance = null;
        private static readonly object padlock = new object();

        UserIdentity()
        {
        }

        public static UserIdentity Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserIdentity();
                    }
                    return instance;
                }
            }
        }


        public CurrentSession CustomUserSession
        {
            get
            {
                return SessionAs<CurrentSession>();
            }
        }

        public void CheckRequestPermission(IRequest httpReq, IResponse httpRes)
        {

            if (CustomUserSession.Permissions == null || !CustomUserSession.Permissions.Contains(httpReq.RawUrl))
            {
                throw new HttpError(HttpStatusCode.Unauthorized);
            }


        }

    }
}
