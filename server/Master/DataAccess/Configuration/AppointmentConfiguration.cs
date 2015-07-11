using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class AppointmentConfiguration : EntityTypeConfiguration<Appointment>
   {
      public AppointmentConfiguration()
      {
         this.Property(a => a.Paid).IsRequired();
         this.Property(a => a.Confirmation).IsOptional().HasMaxLength(150);
         this.Property(a => a.Start).IsOptional().HasColumnType("datetime");
         this.Property(a => a.Duration).IsOptional();
         this.Property(a => a.Remarks).HasMaxLength(2000);
         this.Property(a => a.EmployeeRequested).IsOptional();
         HasRequired(a => a.Customer).WithMany(c => c.CustomerAppointments).HasForeignKey(a => a.CustomerId);
         HasRequired(a => a.Employee).WithMany(e => e.EmployeeAppointments).HasForeignKey(a => a.EmployeeId);
         HasRequired(a => a.Service).WithMany(s => s.Appointments).HasForeignKey(a => a.ServiceId);
      }
   }
}
