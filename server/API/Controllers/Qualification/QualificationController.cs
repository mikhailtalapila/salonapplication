using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Qualification
{
    public class QualificationController : ApiBaseController
    {
       public QualificationController(SalonDbContext db):base(db)
       {

       }

       public IEnumerable<QualificationModel> Get()
       {
          var qualifications = from q in _db.Qualifications
                               orderby q.ServiceId
                               select new QualificationModel
                               {
                                  QualificationId = q.QualificationId,
                                  EmployeeFirstName = q.Employee.FirstName,
                                  EmployeeLastName = q.Employee.LastName,
                                  ServiceName = q.Service.ServiceName
                               };
          return qualifications;
       }

       public QualificationModel get(int id)
       {
          var qualification = _db.Qualifications.FirstOrDefault(q => q.QualificationId == id);
          return new QualificationModel
          {
             QualificationId = qualification.QualificationId,
             EmployeeFirstName = qualification.Employee.FirstName,
             EmployeeLastName = qualification.Employee.LastName,
             ServiceName = qualification.Service.ServiceName
          };
       }
    }
}
