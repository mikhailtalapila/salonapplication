using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class QualificationConfiguration : EntityTypeConfiguration<Qualification>
   {
      public QualificationConfiguration()
      {
         HasRequired(q => q.Employee).WithMany(e => e.EmployeeQualifications).HasForeignKey(q => q.EmployeeId);
         HasRequired(q => q.Service).WithMany(s => s.Qualifications).HasForeignKey(q => q.ServiceId);
      }
   }
}
