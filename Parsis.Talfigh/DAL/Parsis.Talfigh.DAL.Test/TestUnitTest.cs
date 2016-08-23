using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;
using Parsis.Talfigh.DAL.Infrastructure;

namespace Parsis.Talfigh.DAL.Test
{
    [TestClass]
    public class TestUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            UnitOfWork uow = new UnitOfWork(new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["TalfighConnection"].
                ConnectionString, SqlServerDialect.Provider));

            var result =  uow.TestRepository.GetByCode("testcode");

            Assert.IsNotNull(result);
        }
    }
}
