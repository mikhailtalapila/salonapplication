using API.Controllers.Service;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.ServiceType
{
    public class ServiceTypeController : ApiBaseController
    {
       public ServiceTypeController(SalonDbContext db):base(db)
       {

       }

       public IEnumerable<ServiceTypeModel> Get()
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
          return serviceTypes;
       }

       public ServiceTypeModel Get(int id)
       {
          var serviceType = _db.ServiceTypes.FirstOrDefault(st => st.ServiceTypeId == id);
          return new ServiceTypeModel
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
       }
    }
}
