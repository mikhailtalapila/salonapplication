using API.Controllers.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers.Customers
{
   public class CustomerModel
   {
      public int CustomerId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
      public string AlternatePhoneNumber { get; set; }
      public string Email { get; set; }
      public string Gender { get; set; }
      public string ImageSource { get; set; }
      public string Remarks { get; set; }
      public IEnumerable<AppointmentOutModel> Appointments { get; set; }
   }
}