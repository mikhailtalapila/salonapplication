using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Qualifications
{
    public class QualificationsController : ApiBaseController
    {
       public QualificationsController(SalonDbContext db):base(db)
       {

       }


       // GET api/qualifications
       public HttpResponseMessage Get()
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
          if (qualifications == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<IEnumerable<QualificationModel>>(HttpStatusCode.OK, qualifications);          
       }


       // GET  api/qualifications/1
       public HttpResponseMessage get(int id)
       {
          var qualification = _db.Qualifications.FirstOrDefault(q => q.QualificationId == id);
          var qual= new QualificationModel
          {
             QualificationId = qualification.QualificationId,
             EmployeeFirstName = qualification.Employee.FirstName,
             EmployeeLastName = qualification.Employee.LastName,
             ServiceName = qualification.Service.ServiceName
          };
          if (qualification == null) throw new HttpResponseException(HttpStatusCode.NotFound);
          return Request.CreateResponse<QualificationModel>(HttpStatusCode.OK, qual);
       }

       //POST api/qualifications
       public HttpResponseMessage Post([FromBody] QualificationModel values)
       { 
         var empId=_db.Employees.Where(e=>e.FirstName==values.EmployeeFirstName).Where(e=>e.LastName==values.EmployeeLastName).FirstOrDefault().EmployeeId;
         var serviceId=_db.Services.FirstOrDefault(s=>s.ServiceName==values.ServiceName).ServiceId;
         var qualification = new Qualification
         {
            EmployeeId = empId,
            ServiceId = serviceId
         };
         var q = _db.Qualifications.Add(qualification);
         _db.SaveChanges();
         _db.SaveChanges();
         if (q != null)
         {
            var msg = new HttpResponseMessage(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + "/" + qualification.QualificationId.ToString());
            return msg;
         }
         else
         {
            var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
            return msg;
         }
       }

       // PUT api/qualifications/2
       public HttpResponseMessage Put(int id, [FromBody] Qualification qualification)
       {
          var status = _db.Qualifications.Attach(qualification);
          var entry = _db.Entry(qualification);
          entry.Property(p => p.EmployeeId).IsModified = true;
          entry.Property(p => p.ServiceId).IsModified = true;
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }

       // DELETE api/qualifications/4
       public HttpResponseMessage Delete(int id)
       {
          var qualification = new Qualification { QualificationId = id };
          _db.Qualifications.Attach(qualification);
          var status = _db.Qualifications.Remove(qualification);
          _db.SaveChanges();
          if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
          throw new HttpResponseException(HttpStatusCode.NotFound);
       }
    }
}
