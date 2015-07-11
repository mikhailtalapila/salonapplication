using DataAccess.Configuration;
using DataAccess.Models;
using Master.API.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
   public class SalonDbContext : DbContext
   {
      public SalonDbContext()
         : base("DefaultConnection")
      {
      }

      public static SalonDbContext Create()
      {
         return new SalonDbContext();
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Configurations.Add(new AppointmentConfiguration());
         modelBuilder.Configurations.Add(new CustomerConfiguration());
         modelBuilder.Configurations.Add(new EmployeeConfiguration());
         modelBuilder.Configurations.Add(new EmployeeScheduleConfiguration());
         modelBuilder.Configurations.Add(new QualificationConfiguration());
         modelBuilder.Configurations.Add(new ServiceConfiguration());
         modelBuilder.Configurations.Add(new ServiceTypeConfiguration());
         modelBuilder.Configurations.Add(new TimeSlotConfiguration());
      }

      public DbSet<Appointment> Appointments { get; set; }
      public DbSet<Customer> Customers { get; set; }
      public DbSet<Employee> Employees { get; set; }
      public DbSet<EmployeeSchedule> EmployeeSchedule { get; set; }
      public DbSet<Qualification> Qualifications { get; set; }
      public DbSet<Service> Services { get; set; }
      public DbSet<ServiceType> ServiceTypes { get; set; }
      public DbSet<TimeSlot> TimeSlots { get; set; }
   }
}
