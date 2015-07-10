using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext():base("DefaultConnection")
      {
      }

      public static ApplicationDbContext Create()
      {
         return new ApplicationDbContext();
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Customer>().ToTable("Customers", "public");
      }

      public DbSet<Customer> Customers { get; set; }
   }
}
