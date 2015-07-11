using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
   {
      public EmployeeConfiguration()
      {
         this.Property(e => e.FirstName).HasMaxLength(100).IsOptional();
         this.Property(e => e.LastName).HasMaxLength(100).IsOptional();
         this.Property(e => e.ImageSource).HasMaxLength(1000).IsOptional();
         this.Property(e => e.Remarks).HasMaxLength(2000).IsOptional();
      }
   }
}
