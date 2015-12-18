using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Appointments
{
    public class AppointmentsController : ApiBaseController
    {
       public AppointmentsController(SalonDbContext db):base(db)
       {

       }

       // GET /api/appointments
       public HttpResponseMessage Get([FromUri]TimePeriod period)
       {
          
          var appointments = from a in _db.Appointments
                             orderby a.Start
                             where (a.Start>=period.StartTime &&
                                    DbFunctions.AddMinutes(a.Start,a.Duration)<period.EndTime)
                             select new AppointmentOutModel
                             {
                                AppointmentId = a.AppointmentId,
                                CustomerId=a.CustomerId,
                                CustomerFirstName = a.Customer.FirstName,
                                CustomerLastName = a.Customer.LastName,
                                CustomerPhoneNumber=a.Customer.PhoneNumber,
                                EmployeeId=a.EmployeeId,
                                EmployeeFirstName = a.Employee.FirstName,
                                EmployeeLastName = a.Employee.LastName,
                                ServiceId=a.ServiceId,
                                ServiceName = a.Service.ServiceName,
                                ServicePrice = a.Service.Price,
                                AppointmentStartTime = a.Start,
                                AppointmentDurationInMins = a.Duration,
                                CustomerPaid = a.Paid,
                                AppointmentConfirmation = a.Confirmation,
                                IsEmployeeRequested = a.EmployeeRequested,
                                AppointmentRemarks = a.Remarks
                             };
          if (appointments == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<IEnumerable<AppointmentOutModel>>(HttpStatusCode.OK, appointments);
       }


       // GET  /api/appointments/3
       public HttpResponseMessage Get(int id)
       {
          var appointment = _db.Appointments.FirstOrDefault(a => a.AppointmentId == id);
          if (appointment == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          var appt = new AppointmentOutModel
           {
             AppointmentId = appointment.AppointmentId,
             CustomerId=appointment.CustomerId,
             CustomerFirstName = appointment.Customer.FirstName,
             CustomerLastName = appointment.Customer.LastName,
             CustomerPhoneNumber=appointment.Customer.PhoneNumber,
             EmployeeId=appointment.EmployeeId,
             EmployeeFirstName = appointment.Employee.FirstName,
             EmployeeLastName = appointment.Employee.LastName,
             ServiceId=appointment.ServiceId,
             ServiceName = appointment.Service.ServiceName,
             ServicePrice = appointment.Service.Price,
             AppointmentStartTime = appointment.Start,
             AppointmentDurationInMins = appointment.Duration,
             CustomerPaid = appointment.Paid,
             AppointmentConfirmation = appointment.Confirmation,
             IsEmployeeRequested = appointment.EmployeeRequested,
             AppointmentRemarks = appointment.Remarks
          };
             return Request.CreateResponse<AppointmentOutModel>(HttpStatusCode.OK, appt);         
       }


       // POST /api/appointments
       public HttpResponseMessage Post([FromBody] AppointmentInModel values)
       { 
          var custId=_db.Customers.FirstOrDefault(c=>c.PhoneNumber==values.CustomerPhoneNumber).CustomerId;
          var empId=_db.Employees.Where(e=>e.FirstName==values.EmployeeFirstName).Where(e=>e.LastName==values.EmployeeLastName).FirstOrDefault().EmployeeId;
          var servId=_db.Services.FirstOrDefault(e=>e.ServiceName==values.ServiceName).ServiceId;
          var appointment = new Appointment
          {
            CustomerId=custId,
            EmployeeId=empId,
            ServiceId=servId,
            Start=values.AppointmentStartTime,
            Duration=values.AppointmentDurationInMins,
            Paid=values.CustomerPaid,
            Confirmation=values.AppointmentConfirmation,
            EmployeeRequested=values.IsEmployeeRequested,
            Remarks=values.AppointmentRemarks
          };
          var appt = _db.Appointments.Add(appointment);
          _db.SaveChanges();
          if (appt != null)
          {
             var msg = new HttpResponseMessage(HttpStatusCode.Created);
             msg.Headers.Location = new Uri(Request.RequestUri + "/" + appointment.AppointmentId.ToString());
             return msg;
          }
          else
          {
             var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
             return msg;
          }

       }

       // PUT api/appointments/4
       public HttpResponseMessage Put(int id, [FromBody] Appointment app)
       {          
          var status = _db.Appointments.Attach(app);
          var entry = _db.Entry(app);
          entry.Property(a => a.CustomerId).IsModified = true;
          entry.Property(a => a.EmployeeId).IsModified = true;
          entry.Property(a => a.ServiceId).IsModified = true;
          entry.Property(a => a.Start).IsModified = true;
          entry.Property(a => a.Duration).IsModified = true;
          entry.Property(a => a.Paid).IsModified = true;
          entry.Property(a => a.Confirmation).IsModified = true;
          entry.Property(a => a.EmployeeRequested).IsModified = true;
          entry.Property(a => a.Remarks).IsModified = true;
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }

       // DELETE api/appointments/4
       public HttpResponseMessage Delete(int id)
       {
          var appointment = new Appointment { AppointmentId = id };
          _db.Appointments.Attach(appointment);
          var status=_db.Appointments.Remove(appointment);
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }
    }
}
