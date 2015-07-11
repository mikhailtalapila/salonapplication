using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class Employee
   {
      public int EmployeeId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string ImageSource { get; set; }
      public string Remarks { get; set; }

      public virtual ICollection<Qualification> EmployeeQualifications { get; set; }
      public virtual ICollection<Appointment> EmployeeAppointments { get; set; }
      public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
   }
}
