using Parsis.Talfigh.DAL.Domain.Base;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parsis.Talfigh.DAL.Infrastructure
{
    public class ORMLiteDbFactory 
    {
        public static ORMLiteDbFactory Instance { get {return  new ORMLiteDbFactory(); } }


        private static string GetSqlServerBuildDb()
        {

            return ConfigurationManager.ConnectionStrings["TalfighConnection"].ConnectionString;
        }
        public void dataBaseFactory()
        {

            var dbFactory = new OrmLiteConnectionFactory(
                GetSqlServerBuildDb(), SqlServerDialect.Provider);
            try
            {

                using (var db = dbFactory.Open())
                {
                   
                    db.CreateTableIfNotExists<Test>();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
