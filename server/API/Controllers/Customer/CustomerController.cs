using API.Controllers.Appointment;
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
                             LastName = c.LastName,
                             PhoneNumber = c.PhoneNumber,
                             AlternatePhoneNumber = c.AlternatePhoneNumber,
                             Email = c.Email,
                             Gender = c.Gender,
                             ImageSource = c.ImageSource,
                             Remarks = c.Remarks,
                             Appointments = from a in c.CustomerAppointments
                                           orderby a.Start
                                           select new AppointmentModel 
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
          return customers;
       }

       public CustomerModel get(int id)
       {
          var customer = _db.Customers.FirstOrDefault(c => c.CustomerId == id);
          return new CustomerModel
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
                              select new AppointmentModel
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
       }
    }
}
