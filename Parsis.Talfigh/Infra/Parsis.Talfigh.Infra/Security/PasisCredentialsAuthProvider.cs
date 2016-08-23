using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.Infra.Security
{
    public class PasisCredentialsAuthProvider : CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            
            return (userName == "test" && password == "123");
        }

        public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            var customSession = session as CurrentSession;
            if (customSession != null)
            {

                customSession.FirstName = "Clark";
                customSession.LastName = "Kent";
                customSession.SuperHeroIdentity = "Superman";
                session.Roles = new List<string>();
                session.Permissions = new List<string>();
                session.Permissions.Add("GetTest");

            }
            authService.SaveSession(customSession, SessionExpiry);
            return base.OnAuthenticated(authService, session, tokens, authInfo);

        }

    }
}
