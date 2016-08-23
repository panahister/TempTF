using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Web;

namespace Parsis.Talfigh.Infra.Security
{
    public class GuestAttribute : RequestFilterAttribute
    {
        //public void GuestAttribute(IRequest req, IResponse res, object responseDto)
        //{
          
        //}
        public override void Execute(IRequest req, IResponse res, object responseDto)
        {
           
        }
    }
}
