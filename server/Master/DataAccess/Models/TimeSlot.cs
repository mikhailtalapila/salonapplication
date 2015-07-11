﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class TimeSlot
   {
      public int TimeSlotId { get; set; }
      public DateTime? Start { get; set; }
      public int Duration { get; set; }

      public virtual ICollection<EmployeeSchedule> EmployeeScheduleTimeSlots { get; set; }
   }
}
