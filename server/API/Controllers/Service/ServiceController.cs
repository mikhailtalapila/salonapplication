using API.Controllers.Qualification;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Service
{
    public class ServiceController : ApiBaseController
    {
       public ServiceController(SalonDbContext db):base(db)
       {

       }

       public IEnumerable<ServiceModel> Get()
       {
          var services = from s in _db.Services
                         orderby s.ServiceName
                         select new ServiceModel
                         {
                            ServiceId = s.ServiceId,
                            ServiceName = s.ServiceName,
                            Price = s.Price,
                            Qualifications = from q in s.Qualifications
                                             orderby q.EmployeeId
                                             select new QualificationModel 
                                             {
                                                QualificationId=q.QualificationId,
                                                EmployeeFirstName=q.Employee.FirstName,
                                                EmployeeLastName=q.Employee.LastName
                                             }
                         };
          return services;
       }

       public ServiceModel Get(int id)
       {
          var service = _db.Services.FirstOrDefault(s => s.ServiceId == id);
          return new ServiceModel
          {
             ServiceId = service.ServiceId,
             ServiceName = service.ServiceName,
             Price = service.Price,
             Qualifications = from q in service.Qualifications
                              orderby q.EmployeeId
                              select new QualificationModel
                              {
                                 QualificationId = q.QualificationId,
                                 EmployeeFirstName = q.Employee.FirstName,
                                 EmployeeLastName = q.Employee.LastName
                              }
          };
       }
    }
}
