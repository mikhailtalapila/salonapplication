using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class ServiceTypeConfiguration:EntityTypeConfiguration<ServiceType>
   {
      public ServiceTypeConfiguration()
      {
         this.Property(st => st.ServiceTypeName).IsRequired().HasMaxLength(200);
      }
   }
}
