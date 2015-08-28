using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
   public class NoteConfiguration:EntityTypeConfiguration<Note>
   {
      public NoteConfiguration ()
	   {
         this.Property(n=>n.NoteDescription).IsRequired().HasMaxLength(2500);
	   }
   }
}
