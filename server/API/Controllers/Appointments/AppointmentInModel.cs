using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.Appointments
{
   public class AppointmentInModel
   {
      public int AppointmentId { get; set; }
      public string CustomerPhoneNumber { get; set; }
      public string EmployeeFirstName { get; set; }
      public string EmployeeLastName { get; set; }
      public string ServiceName { get; set; }
      public decimal ServicePrice { get; set; }      
      public DateTime AppointmentStartTime { get; set; }
      public int AppointmentDurationInMins { get; set; }
      public bool CustomerPaid { get; set; }
      public string AppointmentConfirmation { get; set; }
      public bool IsEmployeeRequested { get; set; }
      public string AppointmentRemarks { get; set; }
   }
}