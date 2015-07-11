using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Customer
{
   [AllowAnonymous]
    public class CustomerController: ApiBaseController
    {
       public CustomerController(SalonDbContext db):base(db)
       {

       }

       
       public IEnumerable<CustomerModel> Get()
       {
          var customers = from c in _db.Customers
                          orderby c.FirstName
                          select new CustomerModel
                          {
                             CustomerId = c.CustomerId,
                             FirstName = c.FirstName,
                             LastName = c.LastName
                          };
          return customers;
       }

       public CustomerModel get(int id)
       {
          var customer = _db.Customers.FirstOrDefault(c => c.CustomerId == id);
          return new CustomerModel
            {
               CustomerId = customer.CustomerId,
               FirstName = customer.FirstName,
               LastName = customer.LastName
            };
       }
    }
}
