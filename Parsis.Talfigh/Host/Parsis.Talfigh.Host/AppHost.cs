using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Funq;
using ServiceStack;
using ServiceStack.Mvc;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;
using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.DAL.Repository.Base;
using ServiceStack.Admin;
using Parsis.Talfigh.Service.ServiceInterface;
using ServiceStack.Auth;
using ServiceStack.Configuration;
using ServiceStack.Caching;
using ServiceStack.Web;
using Parsis.Talfigh.Business.Service;
using System.Net;
using Parsis.Talfigh.Security.Service;
using Parsis.Talfigh.Security.Model;
using ServiceStack.Validation;
using Parsis.Talfigh.DAL.Repository.Security;
using Parsis.Talfigh.Security.Helper;

namespace Parsis.Talfigh.Host
{
    public class AppHost : AppHostBase
    {
        //
        public AppHost()
            : base("Parsis.Talfigh", new[] { typeof(Parsis.Talfigh.Service.ServiceInterface.TestsService).Assembly, typeof (Parsis.Talfigh.Security.Service.ServiceInterface.SecurityServices).Assembly } )
        {

        }

       

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                HandlerFactoryPath = "api",
            });

            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            container.Register<IDbConnectionFactory>(
            new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["TalfighConnection"].ConnectionString, SqlServerDialect.Provider));

            container.RegisterAutoWiredType(typeof(UnitOfWork), typeof(IUnitOfWork));
            container.RegisterAutoWiredType(typeof(UserHelper), typeof(IUserHelper));
            container.RegisterAutoWiredType(typeof(UserRepository), typeof(IUserRepository));
            container.RegisterAutoWiredType(typeof(RoleRepository), typeof(IRoleRepository));
            container.RegisterAutoWiredType(typeof(UserRepository), typeof(IUserRepository));
            container.RegisterAutoWiredType(typeof(ResourceRepository), typeof(IResourceRepository));
            container.RegisterAutoWiredType(typeof(PermissionRepository), typeof(IPermissionRepository));

            container.RegisterAutoWiredType(typeof(UserService), typeof(IUserService));
            container.RegisterAutoWiredType(typeof(UserIdentity), typeof(IUserIdentity));
            container.RegisterAutoWiredType(typeof(RoleService), typeof(IRoleService));

            container.RegisterAutoWiredType(typeof(TestRepository), typeof(ITestRepository));

            container.RegisterAutoWiredType(typeof(TestService), typeof(ITestService));



            Plugins.Add(new AutoQueryFeature { MaxLimit = 100 });

            Plugins.Add(new AdminFeature());

            Plugins.Add(new CorsFeature());

            SetConfig(new HostConfig
            {
                DefaultContentType = MimeTypes.Json
            });

            SetConfig(new HostConfig { DebugMode = false });

            this.ServiceExceptionHandlers.Add((httpReq, request, exception) =>
            {
                var dd = (HttpError)exception;
                return new HttpError(401, "ssss", "ssss");

            });

            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<ISessionFactory>(c => new SessionFactory(c.Resolve<ICacheClient>()));

            Plugins.Add(new AuthFeature(
                () => new CurrentSession(),
                new IAuthProvider[]
                {
                    new PasisCredentialsAuthProvider(HostContext.Resolve<IUserService>(),HostContext.Resolve<IUserIdentity>()),
                    new BasicAuthProvider()
                }, "http://www.google.com")
            );

            //this.ConfigureValidation(container);

            Plugins.Add(new ValidationFeature());


            }



        private void ConfigureValidation(Container container)
        {
            // Provide fluent validation functionality for web services
            Plugins.Add(new ValidationFeature());

            container.RegisterValidators(typeof(AppHost).Assembly);
        }

    }
}