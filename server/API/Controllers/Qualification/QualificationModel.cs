using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.Qualification
{
   public class QualificationModel
   {
      public int QualificationId { get; set; }
      public string EmployeeFirstName { get; set; }
      public string EmployeeLastName { get; set; }
      public string ServiceName { get; set; }
   }
}