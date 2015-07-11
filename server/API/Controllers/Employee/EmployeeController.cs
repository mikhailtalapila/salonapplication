using API.Controllers.Appointment;
using API.Controllers.EmployeeSchedule;
using API.Controllers.Qualification;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Employee
{
    public class EmployeeController : ApiBaseController
    {
       public EmployeeController(SalonDbContext db):base(db)
       {

       }

       public IEnumerable<EmployeeModel> Get()
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
                                            select new AppointmentModel
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
          return employees;
       }

       public EmployeeModel get(int id)
       {
          var employee = _db.Employees.FirstOrDefault(e => e.EmployeeId == id);
          return new EmployeeModel
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
                            select new AppointmentModel
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
       }
    }
}
