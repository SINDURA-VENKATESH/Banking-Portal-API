using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BankingPortal.Controllers
{

    public class LoginController : ApiController
    {
        private ImasterEntities dbobj = new masterEntities();
        public HttpResponseMessage Post([FromBody] login_table details)
        {
            List<login_table> loginlist = dbobj.login_table.ToList();
            login_table logindetail = loginlist.Where(x => x.username == details.username && x.passwords == details.passwords).FirstOrDefault();
            if(logindetail==null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User", Configuration.Formatters.JsonFormatter);
            }
            else
            {

                string token = AuthenticationModule.GenerateTokenForUser(details.username);
                return Request.CreateResponse(HttpStatusCode.OK, token, Configuration.Formatters.JsonFormatter);
            }


        }

    }
}