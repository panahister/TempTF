using Parsis.Talfigh.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parsis.Talfigh.Security.Models
{
    public class UserToken
    {
        public long Id
        {
            get;
            set;
        }
        public long UserId
        {
            get;
            set;
        }

        public User User
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public DateTime CreateDateTime
        {
            get;
            set;
        }

        public DateTime ExpireDateTime
        {
            get;
            set;
        }

        public EntityStatus Status
        {
            get;
            set;
        }

        public string RefreshKey
        {
            get;
            set;
        }

    }
}
