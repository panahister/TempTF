using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;
using Parsis.Talfigh.Security.Model;

namespace Parsis.Talfigh.Security.Service
{
    public class PasisCredentialsAuthProvider : CredentialsAuthProvider
    {
        private IUserService _userService;
        private IUserIdentity _userIdentity;
        public PasisCredentialsAuthProvider(IUserService userService, IUserIdentity userIdentity)
        {
            _userService = userService;
            _userIdentity = userIdentity;
        }
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {

            var success = _userService.SignInSync(new Models.Login() { Email = userName, Password = password });

            //if (success)
            //{
            //    _userIdentity.CurrentSession.UserName = userName;

            //    authService.SaveSession(_userIdentity.CurrentSession);
            //}

            return success;
        }

        //public override object Authenticate(IServiceBase authService, IAuthSession session, Authenticate request)
        //{
        //    var success = _userService.SignInSync(new Models.Login() { Email = request.UserName, Password = request.Password });

        //    return base.Authenticate(authService, session, request);
        //}


        public override object Authenticate(IServiceBase authService, IAuthSession session, Authenticate request)
        {
            //if (SkipPasswordVerificationForInProcessRequests && authService.Request.IsInProcessRequest())
            //{
            //    new PrivateAuthValidator().ValidateAndThrow(request);
            //    return AuthenticatePrivateRequest(authService, session, request.UserName, request.Password, request.Continue);
            //}

            //new CredentialsAuthValidator().ValidateAndThrow(request);
            return Authenticate(authService, session, request.UserName, request.Password, request.Continue);
        }


        protected object Authenticate(IServiceBase authService, IAuthSession session, string userName, string password, string referrerUrl)
        {
            if (!LoginMatchesSession(session, userName))
            {
                authService.RemoveSession();
                session = authService.GetSession();
            }

            if (TryAuthenticate(authService, userName, password))
            {
                session.IsAuthenticated = true;

                if (session.UserAuthName == null)
                    session.UserAuthName = userName;

                var response = OnAuthenticated(authService, session, null, null);
                if (response != null)
                    return response;

                return new AuthenticateResponse
                {
                    UserId = session.UserAuthId,
                    UserName = userName,
                    SessionId = session.Id,
                    DisplayName = session.DisplayName
                        ?? session.UserName
                        ?? "{0} {1}".Fmt(session.FirstName, session.LastName).Trim(),
                    ReferrerUrl = referrerUrl
                };
            }

            throw HttpError.Unauthorized(ErrorMessages.InvalidUsernameOrPassword);
        }


        public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
           var identity =  _userService.SetAndGetUserIdentity(session);

            var currentSession = session as CurrentSession;

            currentSession.FirstName = identity.User.FirstName;
            currentSession.LastName = identity.User.LastName;
            currentSession.Roles = identity.Roles.Select(c => c.Title).ToList();
            currentSession.Permissions = identity.Permissions.Select(c => c.key).ToList();

            authService.SaveSession(currentSession, SessionExpiry);

          var ff =   _userIdentity.CurrentSession;

            return base.OnAuthenticated(authService, session, tokens, authInfo);

        }

    }
}
