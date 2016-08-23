using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.Security.Models
{
   public  class DashboardMenu
    {     
        public long id
        {
            get;
            set;
        }
        public long? parentId
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }

       
        public string key
        {
            get;
            set;
        }

        
        public string value
        {
            get;
            set;
        }
    }
}
