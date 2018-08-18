using Akic.Core.Domain.Module;
using Akic.Repository;
using Akic.WebApi.App_Start.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Akic.WebApi.Controllers
{
    [RoutePrefix("api/user")]
    //[AccessKeyAttribute]
        [EnableCors("*","*","*")]
    public class UserController : ApiController
    {
        IRepository<User> _user = new EfRepository<User>();
 
        // GET api/userapi/GetAllUser
        [HttpGet]
        public IEnumerable<User> GetAllUser()
        {
            return _user.GetList();
        }
        [HttpGet]
        public User GetUserByID(string id)
        {
            var getUser = _user.QueryWhere(t => t.Id == id);
            if (getUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return getUser;
        }

    
    }
}
