using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class EmployeeSchedule
   {
      public int EmployeeScheduleId { get; set; }
      public int EmployeeId { get; set; }
      public int TimeSlotId { get; set; }

      public virtual Employee Employee { get; set; }
      public virtual TimeSlot TimeSlot { get; set; }
   }
}
