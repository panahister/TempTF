using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsis.Talfigh.DAL.Repository.Base;
using Parsis.Talfigh.DAL.Repository.Security;

namespace Parsis.Talfigh.DAL.Infrastructure
{
    public interface IUnitOfWork
    {

        #region SECURITY
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IUserSessionRepository UserSessionRepository { get; }

        #endregion

        ITestRepository TestRepository { get; }


    }
}
