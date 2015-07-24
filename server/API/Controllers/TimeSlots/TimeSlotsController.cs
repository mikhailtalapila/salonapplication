using API.Controllers.EmployeeSchedules;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.TimeSlots
{
    public class TimeSlotsController : ApiBaseController
    {
       public TimeSlotsController(SalonDbContext db):base(db)
       {

       }


       // GET api/timeslots
       public HttpResponseMessage Get()
       {
          var timeSlots = from ts in _db.TimeSlots
                          orderby ts.Start
                          select new TimeSlotModel
                          {
                             TimeSlotId = ts.TimeSlotId,
                             TimeSlotStartTime = ts.Start,
                             TimeSlotDuration = ts.Duration,
                             EmployeeSchedules = from es in ts.EmployeeScheduleTimeSlots
                                                 orderby es.EmployeeId
                                                 select new EmployeeScheduleModel
                                                 {
                                                    EmployeeScheduleId = es.EmployeeScheduleId,
                                                    EmployeeFirstName = es.Employee.FirstName,
                                                    EmployeeLastName = es.Employee.LastName
                                                 }
                          };
          if (timeSlots == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<IEnumerable<TimeSlotModel>>(HttpStatusCode.OK, timeSlots);
         
       }


       //GET api/timeslots/2
       public HttpResponseMessage Get(int id)
       {
          var timeSlot = _db.TimeSlots.FirstOrDefault(ts => ts.TimeSlotId == id);
          var tmSlot= new TimeSlotModel
          {
             TimeSlotId = timeSlot.TimeSlotId,
             TimeSlotStartTime = timeSlot.Start,
             TimeSlotDuration = timeSlot.Duration,
             EmployeeSchedules = from es in timeSlot.EmployeeScheduleTimeSlots
                                 orderby es.EmployeeId
                                 select new EmployeeScheduleModel
                                 {
                                    EmployeeScheduleId = es.EmployeeScheduleId,
                                    EmployeeFirstName = es.Employee.FirstName,
                                    EmployeeLastName = es.Employee.LastName
                                 }
          };
          if (timeSlot == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<TimeSlotModel>(HttpStatusCode.OK, tmSlot);          
       }


       //POST api/timeslots
       public HttpResponseMessage Post([FromBody]TimeSlotModel values)
       {
          var timeSlot = new TimeSlot
          {
             Start = values.TimeSlotStartTime,
             Duration = values.TimeSlotDuration
          };
          var ts = _db.TimeSlots.Add(timeSlot);
          _db.SaveChanges();
          if(ts!=null)
          {
             var msg = new HttpResponseMessage(HttpStatusCode.Created);
             msg.Headers.Location = new Uri(Request.RequestUri + "/" + timeSlot.TimeSlotId.ToString());
             return msg;
          }
          else
          {
             var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
             return msg;
          }
       }


       //PUT api/timeslots/2
       public HttpResponseMessage Put(int id, [FromBody] TimeSlot timeslot)
       {
          var status = _db.TimeSlots.Attach(timeslot);
          var entry = _db.Entry(timeslot);
          entry.Property(p => p.Start).IsModified = true;
          entry.Property(p => p.Duration).IsModified = true;
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }


       // DELETE api/timeslots/2
       public HttpResponseMessage Delete(int id)
       {
          var timeSlot = new TimeSlot { TimeSlotId = id };
          _db.TimeSlots.Attach(timeSlot);
          var status = _db.TimeSlots.Remove(timeSlot);
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }
    }
}
