using ServiceStack;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Parsis.Talfigh.DAL.Domain.Base;
using System;
using Parsis.Talfigh.Service.ServiceModel.Model;

namespace Parsis.Talfigh.Service.ServiceModel
{
    [Route("/tests", "GET")]
    [Route("/tests", "POST")]
    [Route("/tests/{id}", "PUT")]
    [Route("/tests/{id}", "DELETE")]
   
    public class TestsRequest : IReturn<TestsResponse>
    {
        public long id { get; set; }

        public string code { get; set; }
        public string title { get; set; }
    }
    public class TestsResponse 
    {
        public TestsResponse()
        {
          
            this.Tests = new List<TestsModel>();
        }
        public List<TestsModel> Tests { get; set; }
    }

}