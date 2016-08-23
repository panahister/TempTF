using ServiceStack;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Parsis.Talfigh.DAL.Domain.Base;
using System;
using Parsis.Talfigh.Service.ServiceModel.Model;

namespace Parsis.Talfigh.Service.ServiceModel
{


    [Route("/TestsAuthenticate", "GET")]
    public class TestsAuthenticateRequest : IReturn<TestsAuthenticateResponse>
    {
       
    }

    public class TestsAuthenticateResponse
    {
        public TestsAuthenticateResponse()
        {

            this.TestsAuthenticate = new TestsAuthenticateModel();
        }
        public TestsAuthenticateModel TestsAuthenticate { get; set; }
    }

}