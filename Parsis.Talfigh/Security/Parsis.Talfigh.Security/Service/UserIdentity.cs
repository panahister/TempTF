using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Web;
using Parsis.Talfigh.Security.Model;
using System.Net;

namespace Parsis.Talfigh.Security.Service
{
    public interface IUserIdentity
    {
        CurrentSession CurrentSession { get; }
        bool CheckRequestPermission(IRequest httpReq, IResponse httpRes);
    }
    public class UserIdentity : ServiceStack.Service, IUserIdentity
    {

        //private static UserIdentity instance = null;
        //private static readonly object padlock = new object();

        //UserIdentity()
        //{
        //}

        //public static UserIdentity Instance
        //{
        //    get
        //    {
        //        lock (padlock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new UserIdentity();
        //            }
        //            return instance;
        //        }
        //    }
        //}

        public CurrentSession CurrentSession
        {
            get
            {
                return SessionAs<CurrentSession>();
            }
        }

        public bool CheckRequestPermission(IRequest httpReq, IResponse httpRes)
        {

            if (CurrentSession.Permissions == null || !CurrentSession.Permissions.Contains(httpReq.RawUrl))
            {
                throw new HttpError(HttpStatusCode.Unauthorized);
            }

            return true;


        }

    }
}
