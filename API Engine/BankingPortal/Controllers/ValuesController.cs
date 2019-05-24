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
    //[Authorize]
    public class ValuesController : ApiController
    {

        private ImasterEntities dbobj = new masterEntities();



        public ValuesController()
        { }

        public ValuesController(ImasterEntities db)
        {
            dbobj = db;
        }

        // GET api/values
        public IEnumerable<customers_table> get()
        {
            return dbobj.customers_table.ToList();
        }



        public customers_table get(int id)
        {

            return dbobj.customers_table.Where(c => c.cusid == id).FirstOrDefault();
        }

        // POST api/values
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
