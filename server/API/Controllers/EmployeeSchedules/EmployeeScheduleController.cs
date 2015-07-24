using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.EmployeeSchedules
{
    public class EmployeeSchedulesController : ApiBaseController
    {
       public EmployeeSchedulesController(SalonDbContext db):base(db)
       {

       }

       // GET api/employeeschedules
       public HttpResponseMessage Get()
       {
          var employeeSchedules = from es in _db.EmployeeSchedule
                                 orderby es.EmployeeId
                                 select new EmployeeScheduleModel
                                 {
                                    EmployeeScheduleId = es.EmployeeScheduleId,
                                    EmployeeFirstName = es.Employee.FirstName,
                                    EmployeeLastName = es.Employee.LastName,
                                    TimeSlotStart = es.TimeSlot.Start,
                                    TimeSlotDuration = es.TimeSlot.Duration
                                 };
          if (employeeSchedules == null)
             throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<IEnumerable<EmployeeScheduleModel>>(HttpStatusCode.OK, employeeSchedules);
       }

       // GET api/employeeschedules/4
       public HttpResponseMessage Get(int id)
       {
          var employeeSchedule = _db.EmployeeSchedule.FirstOrDefault(es => es.EmployeeScheduleId == id);
          var empSched = new EmployeeScheduleModel
          {
             EmployeeScheduleId = employeeSchedule.EmployeeScheduleId,
             EmployeeFirstName = employeeSchedule.Employee.FirstName,
             EmployeeLastName = employeeSchedule.Employee.LastName,
             TimeSlotStart = employeeSchedule.TimeSlot.Start,
             TimeSlotDuration = employeeSchedule.TimeSlot.Duration
          };
          if (empSched == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<EmployeeScheduleModel>(HttpStatusCode.OK, empSched);
       }

       // POST api/employeeSchedules
       public HttpResponseMessage Post([FromBody] EmployeeScheduleModel values)
       { 
         var employeeId=_db.Employees.Where(e=>e.FirstName==values.EmployeeFirstName).Where(e=>e.LastName==values.EmployeeLastName).FirstOrDefault().EmployeeId;
         var timeSlotId=_db.TimeSlots.Where(ts=>ts.Start==values.TimeSlotStart).Where(ts=>ts.Duration==values.TimeSlotDuration).FirstOrDefault().TimeSlotId;
         var employeeSchedule = new EmployeeSchedule
         {
           EmployeeId = employeeId,
           TimeSlotId = timeSlotId
         };
         var es = _db.EmployeeSchedule.Add(employeeSchedule);
         _db.SaveChanges();
         if (es != null)
         {
            var msg = new HttpResponseMessage(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + "/" + employeeSchedule.EmployeeScheduleId.ToString());
            return msg;
         }
         else
         {
            var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
            return msg;
         }
       }


       // PUT api/employeeschedules/4
       public HttpResponseMessage Put(int id, [FromBody] EmployeeSchedule employeeSchedule)
       {
          var status = _db.EmployeeSchedule.Attach(employeeSchedule);
          var entry = _db.Entry(employeeSchedule);
          entry.Property(p => p.EmployeeId).IsModified = true;
          entry.Property(p => p.TimeSlotId).IsModified = true;
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }


       // DELETE api/employeeschedules/4
       public HttpResponseMessage Delete(int id)
       {
          var employeeSchedule = new EmployeeSchedule { EmployeeScheduleId = id };
          _db.EmployeeSchedule.Attach(employeeSchedule);
          var status=_db.EmployeeSchedule.Remove(employeeSchedule);
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }
    }
}
