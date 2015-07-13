using API.Controllers.Appointment;
using API.Controllers.Qualification;
using API.Controllers.ServiceType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.Service
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