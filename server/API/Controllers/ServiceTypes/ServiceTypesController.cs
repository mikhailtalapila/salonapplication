using API.Controllers.Services;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.ServiceTypes
{   
    public class ServiceTypesController : ApiBaseController
    {
       public ServiceTypesController(SalonDbContext db):base(db)
       {

       }

       // GET api/servicetypes
       public HttpResponseMessage Get()
       {
          var serviceTypes = from st in _db.ServiceTypes
                             orderby st.ServiceTypeName
                             select new ServiceTypeModel
                             {
                                ServiceTypeId = st.ServiceTypeId,
                                ServiceTypeName = st.ServiceTypeName,
                                Services = from s in st.Services
                                           orderby s.ServiceName
                                           select new ServiceModel 
                                           {
                                              ServiceId=s.ServiceId,
                                             ServiceName=s.ServiceName,
                                             Price=s.Price
                                           }
                             };
          if (serviceTypes == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<IEnumerable<ServiceTypeModel>>(HttpStatusCode.OK, serviceTypes);
          
       }


       // GET api/serviceTypes/2
       public HttpResponseMessage Get(int id)
       {
          var serviceType = _db.ServiceTypes.FirstOrDefault(st => st.ServiceTypeId == id);
          var servType= new ServiceTypeModel
          {
             ServiceTypeId = serviceType.ServiceTypeId,
             ServiceTypeName = serviceType.ServiceTypeName,
             Services = from s in serviceType.Services
                        orderby s.ServiceName
                        select new ServiceModel
                        {
                           ServiceId=s.ServiceId,
                           ServiceName = s.ServiceName,
                           Price = s.Price
                        }
          };
          if (serviceType == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<ServiceTypeModel>(HttpStatusCode.OK, servType);
       }

       //POST api/servicetypes
       public HttpResponseMessage Post([FromBody] ServiceTypeModel values)
       {
          var serviceType = new ServiceType
          {
             ServiceTypeName = values.ServiceTypeName
          };
          var servTp = _db.ServiceTypes.Add(serviceType);
          _db.SaveChanges();
          if (servTp != null)
          {
             var msg = new HttpResponseMessage(HttpStatusCode.Created);
             msg.Headers.Location = new Uri(Request.RequestUri + "/" + serviceType.ServiceTypeId.ToString());
             return msg;
          }
          else
          {
             var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
             return msg;
          }
       }


       //PUT api/serviceTypes/3
       public HttpResponseMessage Put(int id, [FromBody] ServiceType serviceType)
       {
          var status = _db.ServiceTypes.Attach(serviceType);
          var entry = _db.Entry(serviceType);
          entry.Property(p => p.ServiceTypeName).IsModified = true;
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }


       // DELETE api/servicetypes/4
       public HttpResponseMessage Delete(int id)
       {
          var serviceType = new ServiceType { ServiceTypeId = id };
          _db.ServiceTypes.Attach(serviceType);
          var status = _db.ServiceTypes.Remove(serviceType);
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }
    }
}
