using Nelibur.ObjectMapper;
using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.Infra.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using busModel = Parsis.Talfigh.Security.Models;
using dalModel = Parsis.Talfigh.DAL.Domain.Security;

namespace Parsis.Talfigh.Security.Service
{
    public interface IRoleService
    {
        Task<busModel.Role> GetDefaultRole();
    }
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork liteUnitOfWork;

        public RoleService(IUnitOfWork liteUnitOfWork)
        {
            this.liteUnitOfWork = liteUnitOfWork;
        }

        public async Task<busModel.Role> GetDefaultRole()
        {
            try
            {
                var dalRole = await liteUnitOfWork.RoleRepository.GetDefaultRole();

                TinyMapper.Bind<dalModel.Role, busModel.Role>();

                return TinyMapper.Map<busModel.Role>(dalRole);
            }
            catch(Exception)
            {
                throw new ParsisException(ExceptionType.InternalServerError);
            }

            
        }
    }

}
