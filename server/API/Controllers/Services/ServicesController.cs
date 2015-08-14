using API.Controllers.Qualifications;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Services
{
    public class ServicesController : ApiBaseController
    {
       public ServicesController(SalonDbContext db):base(db)
       {

       }

       // GET api/services
       public HttpResponseMessage Get()
       {
          var services = from s in _db.Services
                         orderby s.ServiceType.ServiceTypeName,s.Price
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
                                                EmployeeId=q.EmployeeId,
                                                EmployeeFirstName=q.Employee.FirstName,
                                                EmployeeLastName=q.Employee.LastName,
                                                EmployeeLastInitial=q.Employee.LastInitial,
                                                ImageSource=q.Employee.ImageSource
                                             },
                           ServiceTypeName= s.ServiceType.ServiceTypeName,
                           ImageSource=s.ImageSource,
                           Description=s.Description
                         };
          if (services == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<IEnumerable<ServiceModel>>(HttpStatusCode.OK, services);
       }


       // GET api/services/1
       public HttpResponseMessage Get(int id)
       {
          var service = _db.Services.FirstOrDefault(s => s.ServiceId == id);
          var sevc= new ServiceModel
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
                                 EmployeeLastName = q.Employee.LastName,
                                 ImageSource=q.Employee.ImageSource
                              },
            ServiceTypeName=service.ServiceType.ServiceTypeName,
            Description=service.Description,
            ImageSource=service.ImageSource
          };
          if (sevc == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<ServiceModel>(HttpStatusCode.OK, sevc);
       }


       // POST api/services
       public HttpResponseMessage Post([FromBody] ServiceModel value)
       {
          var servType = _db.ServiceTypes.FirstOrDefault(st => st.ServiceTypeName == value.ServiceTypeName);
          var service = new Service
          {
             ServiceName = value.ServiceName,
             Price = value.Price,
             ServiceTypeId=value.ServiceTypeId,
             Description=value.Description
          };
          var serv = _db.Services.Add(service);
          _db.SaveChanges();
          if (serv != null)
          {
             var msg = new HttpResponseMessage(HttpStatusCode.Created);
             msg.Headers.Location = new Uri(Request.RequestUri + "/" + service.ServiceId.ToString());
             return msg;
          }
          else
          {
             var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
             return msg;
          }
       }

       // PUT api/services/4
       public HttpResponseMessage Put(int id, [FromBody] ServiceModel values)
       {
          var serviceType=_db.ServiceTypes.FirstOrDefault(st=>st.ServiceTypeName==values.ServiceTypeName);
          var serv = new Service
          {
             ServiceId = values.ServiceId,
             ServiceName = values.ServiceName,
             Price = values.Price,
             ServiceTypeId = serviceType.ServiceTypeId
          };
          var status = _db.Services.Attach(serv);
          var entry = _db.Entry(serv);
          entry.Property(e => e.ServiceName).IsModified = true;
          entry.Property(e => e.Price).IsModified = true;
          entry.Property(e => e.ServiceTypeId).IsModified = true;
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }

       // DELETE api/services/4
       public HttpResponseMessage Delete(int id)
       {
          var service = new Service { ServiceId = id };
          _db.Services.Attach(service);
          var status = _db.Services.Remove(service);
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }
    }
}
