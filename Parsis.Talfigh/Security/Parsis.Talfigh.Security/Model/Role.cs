using Parsis.Talfigh.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parsis.Talfigh.Security.Models
{
    public class Role
    {
        [Required()]
        public string Title
        {
            get;
            set;
        }

        [Required()]
        public EntityStatus Status
        {
            get;
            set;
        }

        public bool IsDefault { get; set; }
    }
}
