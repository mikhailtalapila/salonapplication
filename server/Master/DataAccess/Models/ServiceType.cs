using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class ServiceType
   {
      public int ServiceTypeId  { get; set; }
      public string ServiceTypeName { get; set; }

      public virtual ICollection<Service> Services { get; set; }
   }
}
