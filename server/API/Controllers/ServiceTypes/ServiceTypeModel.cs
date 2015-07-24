using API.Controllers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.ServiceTypes
{
   public class ServiceTypeModel
   {
      public int ServiceTypeId { get; set; }
      public string ServiceTypeName { get; set; }
      public IEnumerable<ServiceModel> Services { get; set; }
   }
}