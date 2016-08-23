using ServiceStack;
using Parsis.Talfigh.DAL.Domain.Base;

namespace Parsis.Talfigh.Service.ServiceModel
{
    [Route("/query/Test")]
    public class Querytests : QueryDb<Test> { }
  
}