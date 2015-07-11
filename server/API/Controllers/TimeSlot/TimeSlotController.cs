using API.Controllers.EmployeeSchedule;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.TimeSlot
{
    public class TimeSlotController : ApiBaseController
    {
       public TimeSlotController(SalonDbContext db):base(db)
       {

       }

       public IEnumerable<TimeSlotModel> Get()
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
          return timeSlots;
       }

       public TimeSlotModel Get(int id)
       {
          var timeSlot = _db.TimeSlots.FirstOrDefault(ts => ts.TimeSlotId == id);
          return new TimeSlotModel
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
       }
    }
}
