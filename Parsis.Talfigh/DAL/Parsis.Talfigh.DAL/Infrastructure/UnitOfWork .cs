using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsis.Talfigh.DAL.Repository.Base;
using Parsis.Talfigh.DAL.Repository.Security;

namespace Parsis.Talfigh.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbConnectionFactory dbFactory;


        #region SECURITY
        private UserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(dbFactory);
                }
                return userRepository;
            }
        }


        private RoleRepository roleRepository;
        public IRoleRepository RoleRepository
        {
            get
            {

                if (this.roleRepository == null)
                {
                    this.roleRepository = new RoleRepository(dbFactory);
                }
                return roleRepository;
            }
        }


        private PermissionRepository permissionRepository;
        public IPermissionRepository PermissionRepository
        {
            get
            {

                if (this.permissionRepository == null)
                {
                    this.permissionRepository = new PermissionRepository(dbFactory);
                }
                return permissionRepository;
            }
        }

        private UserSessionRepository userSessionRepository;
        public IUserSessionRepository UserSessionRepository
        {
            get
            {

                if (this.userSessionRepository == null)
                {
                    this.userSessionRepository = new UserSessionRepository(dbFactory);
                }
                return userSessionRepository;
            }
        }

        #endregion

        private TestRepository testRepository;
        public ITestRepository TestRepository
        {
            get
            {

                if (this.testRepository == null)
                {
                    this.testRepository = new TestRepository(dbFactory);
                }
                return testRepository;
            }
        }


        public UnitOfWork(IDbConnectionFactory dbFactory)
        {
            this.dbFactory = dbFactory;
           
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
