using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Parsis.Talfigh.DAL.Domain.Base
{

    [Schema("base")]
   public class Test : BaseEntity
    {

        public Test():base()
        {

        }


        [StringLength(50)]
        [Required()]
        public string Title
        {
            get;
            set;
        }

        [StringLength(05)]
        [Required()]
        public string Code
        {
            get;
            set;
        }

    }
}
