using API.Controllers.Appointments;
using API.Controllers.EmployeeSchedules;
using API.Controllers.Qualifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.Employees
{
   public class EmployeeModel
   {
      public int EmployeeId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string ImageSource { get; set; }
      public string Remarks { get; set; }
      public IEnumerable<QualificationModel> Qualifications { get; set; }
      public IEnumerable<AppointmentOutModel> Appointments { get; set; }
      public IEnumerable<EmployeeScheduleModel> EmployeeSchedules { get; set; }
   }
}