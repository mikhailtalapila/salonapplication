using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class SalonSchedule
   {
      public int SalonScheduleId { get; set; }
      public DateTime Start { get; set; }
      public int Duration { get; set; }
   }
}
