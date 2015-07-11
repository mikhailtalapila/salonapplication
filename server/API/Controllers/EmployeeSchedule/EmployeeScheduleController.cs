using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.EmployeeSchedule
{
    public class EmployeeScheduleController : ApiBaseController
    {
       public EmployeeScheduleController(SalonDbContext db):base(db)
       {

       }

       public IEnumerable<EmployeeScheduleModel> Get()
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
          return employeeSchedules;
       }

       public EmployeeScheduleModel Get(int id)
       {
          var employeeSchedule = _db.EmployeeSchedule.FirstOrDefault(es => es.EmployeeScheduleId == id);
          return new EmployeeScheduleModel
          {
             EmployeeScheduleId = employeeSchedule.EmployeeScheduleId,
             EmployeeFirstName = employeeSchedule.Employee.FirstName,
             EmployeeLastName = employeeSchedule.Employee.LastName,
             TimeSlotStart = employeeSchedule.TimeSlot.Start,
             TimeSlotDuration = employeeSchedule.TimeSlot.Duration
          };
       }
    }
}
