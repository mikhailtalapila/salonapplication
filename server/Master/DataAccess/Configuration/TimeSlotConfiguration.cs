using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class TimeSlotConfiguration : EntityTypeConfiguration<TimeSlot>
   {
      public TimeSlotConfiguration()
      {
         this.Property(t => t.Start).HasColumnType("datetime").IsRequired();
         this.Property(t => t.Duration).IsRequired();
      }
   }
}
