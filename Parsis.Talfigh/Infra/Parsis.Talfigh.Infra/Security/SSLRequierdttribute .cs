using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Web;

namespace Parsis.Talfigh.Infra.Security
{
    public class SSLRequierdttribute : RequestFilterAttribute
    {
        public void ResponseFilter(IRequest req, IResponse res, object responseDto)
        {
          
        }
        public override void Execute(IRequest req, IResponse res, object responseDto)
        {
            if (!req.IsSecureConnection)
                throw new HttpError(statusCode: System.Net.HttpStatusCode.Unauthorized,errorMessage: "dddddddddddddddddd");
        }
    }
}
