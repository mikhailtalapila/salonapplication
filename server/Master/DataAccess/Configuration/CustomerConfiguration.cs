using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.API.Configuration
{
   public class CustomerConfiguration : EntityTypeConfiguration<Customer>
   {
      public CustomerConfiguration()
      {
         this.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
         this.Property(p => p.LastName).IsRequired().HasMaxLength(100);
         this.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(20);
         this.Property(p => p.AlternatePhoneNumber).IsOptional().HasMaxLength(20);
         this.Property(p => p.Email).HasMaxLength(100).IsOptional();
         this.Property(p => p.Remarks).IsOptional().HasMaxLength(2000);
         this.Property(p => p.ImageSource).IsOptional().HasMaxLength(1000);
      }
   }
}
