using API.Controllers.Appointments;
using API.Controllers.Employees;
using API.Controllers.EmployeeSchedules;
using API.Controllers.Qualifications;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Employees
{
    public class EmployeesController : ApiBaseController
    {
       public EmployeesController(SalonDbContext db):base(db)
       {

       }

       // GET api/employees
       public HttpResponseMessage Get()
       {
          var employees = from e in _db.Employees
                          orderby e.EmployeeId
                          select new EmployeeModel
                          {
                             EmployeeId = e.EmployeeId,
                             FirstName = e.FirstName,
                             LastName = e.LastName,
                             ImageSource = e.ImageSource,
                             Remarks = e.Remarks,
                             Qualifications = from q in e.EmployeeQualifications
                                              orderby q.ServiceId
                                              select new QualificationModel
                                              {
                                                 QualificationId = q.QualificationId,
                                                 ServiceName = q.Service.ServiceName
                                              },
                             Appointments = from a in e.EmployeeAppointments
                                            orderby a.Start
                                            select new AppointmentOutModel
                                            {
                                               AppointmentId = a.AppointmentId,
                                               CustomerFirstName = a.Customer.FirstName,
                                               CustomerLastName = a.Customer.LastName,
                                               ServiceName = a.Service.ServiceName,
                                               ServicePrice = a.Service.Price,
                                               AppointmentStartTime = a.Start,
                                               AppointmentDurationInMins = a.Duration,
                                               CustomerPaid = a.Paid,
                                               AppointmentConfirmation = a.Confirmation,
                                               IsEmployeeRequested = a.EmployeeRequested,
                                               AppointmentRemarks = a.Remarks
                                            },
                             EmployeeSchedules = from es in e.EmployeeSchedules
                                                 orderby es.EmployeeScheduleId
                                                 select new EmployeeScheduleModel
                                                 {
                                                    EmployeeScheduleId = es.EmployeeScheduleId,
                                                    EmployeeFirstName = es.Employee.FirstName,
                                                    EmployeeLastName = es.Employee.LastName,
                                                    TimeSlotStart = es.TimeSlot.Start,
                                                    TimeSlotDuration = es.TimeSlot.Duration
                                                 }
                          };
          if (employees == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<IEnumerable<EmployeeModel>>(HttpStatusCode.OK, employees);
          
       }


       // GET api/employees/5
       public HttpResponseMessage Get(int id)
       {
          var employee = _db.Employees.FirstOrDefault(e => e.EmployeeId == id);
          var emp= new EmployeeModel
          {
             EmployeeId = employee.EmployeeId,
             FirstName = employee.FirstName,
             LastName = employee.LastName,
             ImageSource = employee.ImageSource,
             Remarks = employee.Remarks,
             Qualifications = from q in employee.EmployeeQualifications
                              orderby q.ServiceId
                              select new QualificationModel
                              {
                                 QualificationId = q.QualificationId,
                                 ServiceName = q.Service.ServiceName
                              },
             Appointments = from a in employee.EmployeeAppointments
                            orderby a.Start
                            select new AppointmentOutModel
                            {
                               AppointmentId = a.AppointmentId,
                               CustomerFirstName = a.Customer.FirstName,
                               CustomerLastName = a.Customer.LastName,
                               ServiceName = a.Service.ServiceName,
                               ServicePrice = a.Service.Price,
                               AppointmentStartTime = a.Start,
                               AppointmentDurationInMins = a.Duration,
                               CustomerPaid = a.Paid,
                               AppointmentConfirmation = a.Confirmation,
                               IsEmployeeRequested = a.EmployeeRequested,
                               AppointmentRemarks = a.Remarks
                            },
             EmployeeSchedules = from es in employee.EmployeeSchedules
                                 orderby es.EmployeeScheduleId
                                 select new EmployeeScheduleModel
                                 {
                                    EmployeeScheduleId = es.EmployeeScheduleId,
                                    EmployeeFirstName = es.Employee.FirstName,
                                    EmployeeLastName = es.Employee.LastName,
                                    TimeSlotStart = es.TimeSlot.Start,
                                    TimeSlotDuration = es.TimeSlot.Duration
                                 }
          };
          if (emp == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<EmployeeModel>(HttpStatusCode.OK, emp);
       }

       // POST api/employees
       public HttpResponseMessage Post([FromBody] EmployeeModel value)
       {
          var employee = new Employee
             {
                FirstName = value.FirstName,
                LastName = value.LastName,
                ImageSource = value.ImageSource,
                Remarks = value.Remarks
             };
          var emp=_db.Employees.Add(employee);
          _db.SaveChanges();
          if (emp != null)
          {
             var msg = new HttpResponseMessage(HttpStatusCode.Created);
             msg.Headers.Location = new Uri(Request.RequestUri + "/" + employee.EmployeeId.ToString());
             return msg;
          }
          else
          {
            var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
            return msg;
          }
       }

       // PUT api/employees/4
       public HttpResponseMessage Put(int id, [FromBody] Employee emp)
       {
          var status = _db.Employees.Attach(emp);
          var entry = _db.Entry(emp);
          entry.Property(e => e.FirstName).IsModified = true;
          entry.Property(e => e.LastName).IsModified = true;
          entry.Property(e => e.ImageSource).IsModified = true;
          entry.Property(e => e.Remarks).IsModified = true;
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }

       // DELETE api/employees/7
       public HttpResponseMessage Delete(int id)
       {
          var emp = new Employee { EmployeeId = id };
          _db.Employees.Attach(emp);
          var status = _db.Employees.Remove(emp);
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }
    }
}
