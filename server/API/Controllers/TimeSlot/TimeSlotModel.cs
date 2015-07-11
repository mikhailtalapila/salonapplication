﻿using API.Controllers.EmployeeSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.TimeSlot
{
   public class TimeSlotModel
   {
      public int TimeSlotId { get; set; }
      public DateTime? TimeSlotStartTime { get; set; }
      public int TimeSlotDuration { get; set; }
      public IEnumerable<EmployeeScheduleModel> EmployeeSchedules { get; set; }
   }
}