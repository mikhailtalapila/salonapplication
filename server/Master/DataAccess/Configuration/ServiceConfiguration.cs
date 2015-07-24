using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class ServiceConfiguration : EntityTypeConfiguration<Service>
   {
      public ServiceConfiguration()
      {
         this.Property(s => s.ServiceName).IsRequired().HasMaxLength(500);
         this.Property(s => s.Price).IsOptional();
         HasRequired(s => s.ServiceType).WithMany(s => s.Services).HasForeignKey(a => a.ServiceTypeId);
      }
   }
}
