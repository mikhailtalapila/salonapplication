using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class Note
   {
      public int NoteId { get; set; }
      public string NoteDescription { get; set; }
      public DateTime? CreatedOn { get; set; }
      public string CreatedBy { get; set; }
      public bool? Active { get; set; }
      public bool? Completed { get; set; }
      public DateTime? CompletedOn { get; set; }
      public string CompletedBy { get; set; }
   }
}
