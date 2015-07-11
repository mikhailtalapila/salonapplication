using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class EmployeeScheduleConfiguration : EntityTypeConfiguration<EmployeeSchedule>
   {
      public EmployeeScheduleConfiguration()
      {
         HasRequired(es => es.Employee).WithMany(e => e.EmployeeSchedules).HasForeignKey(es => es.EmployeeId);
         HasRequired(es => es.TimeSlot).WithMany(t => t.EmployeeScheduleTimeSlots).HasForeignKey(es => es.TimeSlotId);
      }
   }
}
