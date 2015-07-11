using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.EmployeeSchedule
{
   public class EmployeeScheduleModel
   {
      public int EmployeeScheduleId { get; set; }
      public string EmployeeFirstName { get; set; }
      public string EmployeeLastName { get; set; }
      public DateTime? TimeSlotStart { get; set; }
      public int TimeSlotDuration { get; set; }
   }
}