using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using DataAccess.Context;

namespace API.Controllers
{
    public class ApiBaseController : ApiController
    {
       protected SalonDbContext _db;

       public ApiBaseController(SalonDbContext db)
       {
          _db = db;
       }
    }
}
