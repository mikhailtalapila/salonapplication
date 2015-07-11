using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class Appointment
   {
      public int AppointmentId { get; set; }
      public int CustomerId { get; set; }
      public int EmployeeId { get; set; }
      public int ServiceId { get; set; }
      public DateTime Start { get; set; }
      public int Duration { get; set; }
      public bool Paid { get; set; }
      public string Confirmation { get; set; }
      public bool EmployeeRequested { get; set; }
      public string Remarks { get; set; }


      public virtual Customer Customer { get; set; }
      public virtual Employee Employee { get; set; }
      public virtual Service Service { get; set; }
   }
}
