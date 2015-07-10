using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class Customer
   {
      public Customer()
      {
         Gender = " ";
         ImageSource = string.Empty;
      }

      public int CustomerId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
      public string AlternatePhoneNumber { get; set; }
      public string Email { get; set; }
      [StringLength(1, MinimumLength = 1)]
      public string Gender { get; set; }
      public string ImageSource { get; set; }
      public string Remarks { get; set; }
   }
}
