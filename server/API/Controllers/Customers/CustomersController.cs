using API.Controllers.Appointments;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Models;

namespace API.Controllers.Customers
{
   [AllowAnonymous]
    public class CustomersController: ApiBaseController
    {
       public CustomersController(SalonDbContext db):base(db)
       {

       }

       // GET api/customers
       public HttpResponseMessage Get()
       {
          var customers = from c in _db.Customers
                          orderby c.FirstName
                          select new CustomerModel
                          {
                             CustomerId = c.CustomerId,
                             FirstName = c.FirstName,
                             LastName = c.LastName,
                             PhoneNumber = c.PhoneNumber,
                             AlternatePhoneNumber = c.AlternatePhoneNumber,
                             Email = c.Email,
                             Gender = c.Gender,
                             ImageSource = c.ImageSource,
                             Remarks = c.Remarks,
                             Appointments = from a in c.CustomerAppointments
                                           orderby a.Start descending
                                           select new AppointmentOutModel 
                                           {
                                              AppointmentId=a.AppointmentId,
                                              CustomerFirstName=a.Customer.FirstName,
                                              CustomerLastName=a.Customer.LastName,
                                              EmployeeFirstName=a.Employee.FirstName,
                                              EmployeeLastName=a.Employee.LastName,
                                              ServiceName=a.Service.ServiceName,
                                              ServicePrice=a.Service.Price,
                                              AppointmentStartTime=a.Start,
                                              AppointmentDurationInMins=a.Duration,
                                              CustomerPaid=a.Paid,
                                              AppointmentConfirmation=a.Confirmation,
                                              IsEmployeeRequested=a.EmployeeRequested,
                                              AppointmentRemarks=a.Remarks
                                           }
                          };
          if (customers == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<IEnumerable<CustomerModel>>(HttpStatusCode.OK, customers);
       }
       
       // GET api/customers/5
       public HttpResponseMessage Get(int id)
       {
          var customer = _db.Customers.FirstOrDefault(c => c.CustomerId == id);
          var cust= new CustomerModel
            {
               CustomerId = customer.CustomerId,
               FirstName = customer.FirstName,
               LastName = customer.LastName,
               PhoneNumber = customer.PhoneNumber,
               AlternatePhoneNumber = customer.AlternatePhoneNumber,
               Email = customer.Email,
               Gender = customer.Gender,
               ImageSource = customer.ImageSource,
               Remarks = customer.Remarks,
               Appointments = from a in customer.CustomerAppointments
                              orderby a.Start
                              select new AppointmentOutModel
                              {
                                 AppointmentId = a.AppointmentId,
                                 CustomerFirstName = a.Customer.FirstName,
                                 CustomerLastName = a.Customer.LastName,
                                 EmployeeFirstName = a.Employee.FirstName,
                                 EmployeeLastName = a.Employee.LastName,
                                 ServiceName = a.Service.ServiceName,
                                 ServicePrice = a.Service.Price,
                                 AppointmentStartTime = a.Start,
                                 AppointmentDurationInMins = a.Duration,
                                 CustomerPaid = a.Paid,
                                 AppointmentConfirmation = a.Confirmation,
                                 IsEmployeeRequested = a.EmployeeRequested,
                                 AppointmentRemarks = a.Remarks
                              }
            };
          if (cust == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<CustomerModel>(HttpStatusCode.OK, cust);
       }
       
       // POST api/customers 
       public HttpResponseMessage Post([FromBody] CustomerModel value)
       {
          var customer=new Customer
             {
                FirstName=value.FirstName,
                LastName=value.LastName,
                PhoneNumber=value.PhoneNumber,
                AlternatePhoneNumber=value.AlternatePhoneNumber,
                Email=value.Email,
                Gender=value.Gender,
                Remarks=value.Remarks
             };
          _db.Customers.Add(customer);          
          _db.SaveChanges();
          var msg = new HttpResponseMessage(HttpStatusCode.Created);
          msg.Headers.Location = new Uri(Request.RequestUri + "/"+customer.CustomerId.ToString());
          return msg;
       }

       // PUT api/customers/5
       public HttpResponseMessage Put(int id, [FromBody]Customer cust)
       {
          var status=_db.Customers.Attach(cust);
          var entry = _db.Entry(cust);
          entry.Property(e => e.FirstName).IsModified = true;
          entry.Property(e=>e.LastName).IsModified=true;
          entry.Property(e => e.PhoneNumber).IsModified = true;
          entry.Property(e => e.AlternatePhoneNumber).IsModified = true;
          entry.Property(e => e.Email).IsModified = true;
          entry.Property(e => e.ImageSource).IsModified = true;
          entry.Property(e => e.Remarks).IsModified = true;
          entry.Property(e => e.Gender).IsModified = true;
          _db.SaveChanges();
          if (status!=null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }

       // DELETE api/customers/7
       public HttpResponseMessage Delete(int id)
       {
          var cust = new Customer { CustomerId=id};
          _db.Customers.Attach(cust);
          var status = _db.Customers.Remove(cust);
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }
    }
}
