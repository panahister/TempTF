using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Parsis.Talfigh.DAL.Domain.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
        }

        [PrimaryKey]
        [AutoIncrement]
        public long Id
        {
            get;
            set;
        }

    }
}
