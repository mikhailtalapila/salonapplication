using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Appointment
{
    public class AppointmentController : ApiBaseController
    {
       public AppointmentController(SalonDbContext db):base(db)
       {

       }

       public IEnumerable<AppointmentModel> Get()
       {
          var appointments = from a in _db.Appointments
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
                             };
          return appointments;
       }

       public AppointmentModel Get(int id)
       {
          var appointment = _db.Appointments.FirstOrDefault(a => a.AppointmentId == id);
          return new AppointmentModel
          {
             AppointmentId = appointment.AppointmentId,
             CustomerFirstName = appointment.Customer.FirstName,
             CustomerLastName = appointment.Customer.LastName,
             EmployeeFirstName = appointment.Employee.FirstName,
             EmployeeLastName = appointment.Employee.LastName,
             ServiceName = appointment.Service.ServiceName,
             ServicePrice = appointment.Service.Price,
             AppointmentStartTime = appointment.Start,
             AppointmentDurationInMins = appointment.Duration,
             CustomerPaid = appointment.Paid,
             AppointmentConfirmation = appointment.Confirmation,
             IsEmployeeRequested = appointment.EmployeeRequested,
             AppointmentRemarks = appointment.Remarks
          };
       }
    }
}
