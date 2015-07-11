using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class Qualification
   {
      public int QualificationId { get; set; }
      public int EmployeeId { get; set; }
      public int ServiceId { get; set; }

      public virtual Employee Employee { get; set; }
      public virtual Service Service { get; set; }
   }
}
