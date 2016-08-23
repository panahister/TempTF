using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.Security.Models
{
    public class Identity
    {
        public User User{ get; set; }

        public List<Permission> Permissions { get; set;}

        public List<DashboardMenu> DashboardMenus { get; set; }

        public List<Role> Roles { get; set; }

        
    }
}
