using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class SalonScheduleConfiguration:EntityTypeConfiguration<SalonSchedule>
   {
      public SalonScheduleConfiguration()
      {
         this.Property(a => a.Start).IsRequired();
         this.Property(a => a.Duration).IsRequired();
      }
   }
}
