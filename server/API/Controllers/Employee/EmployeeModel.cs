using API.Controllers.Appointment;
using API.Controllers.EmployeeSchedule;
using API.Controllers.Qualification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.Employee
{
   public class EmployeeModel
   {
      public int EmployeeId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string ImageSource { get; set; }
      public string Remarks { get; set; }
      public IEnumerable<QualificationModel> Qualifications { get; set; }
      public IEnumerable<AppointmentModel> Appointments { get; set; }
      public IEnumerable<EmployeeScheduleModel> EmployeeSchedules { get; set; }
   }
}