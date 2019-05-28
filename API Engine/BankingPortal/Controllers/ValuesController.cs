using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using NLog;
using BankingPortal.Helpers;

namespace BankingPortal.Controllers
{


    [JwtAuthentication]
    
    public class ValuesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ImasterEntities dbobj = new masterEntities();



        public ValuesController()
        { }

        public ValuesController(ImasterEntities db)
        {
            dbobj = db;
        }

        // GET api/values

        [LogClass]
        public IEnumerable<customers_table> get()
        {
            
            return dbobj.customers_table.ToList();
        }


        [LogClass]
        public customers_table get(int id)
        {
            
            return dbobj.customers_table.Where(c => c.cusid == id).FirstOrDefault();
        }

        // POST api/values
        [LogClass]
        public void Post([FromBody]customers_table value)
        {
            ObjectParameter objpar = new ObjectParameter("id", typeof(int));
            int rowsupdated = dbobj.sp_addcustomer(value.cusname, value.cusaddress, value.cusstatus, objpar);

        }

        

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
