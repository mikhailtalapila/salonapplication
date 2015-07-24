using API.Controllers.Appointments;
using API.Controllers.Qualifications;
using API.Controllers.ServiceTypes;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.Services
{
   public class ServiceModel
   {
      public int ServiceId { get; set; }
      public string ServiceName { get; set; }
      public decimal Price { get; set; }
      public IEnumerable<QualificationModel> Qualifications { get; set; }
      public string ServiceTypeName { get; set; }
   }
}