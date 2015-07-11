using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class Service
   {
      public int ServiceId { get; set; }
      public string ServiceName { get; set; }
      public decimal Price { get; set; }

      public virtual ICollection<Appointment> Appointments { get; set; }
      public virtual ICollection<Qualification> Qualifications { get; set; }
   }
}
