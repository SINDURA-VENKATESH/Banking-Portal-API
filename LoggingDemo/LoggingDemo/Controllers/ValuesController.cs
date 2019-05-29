using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LoggingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private ILog logger;
        public ValuesController(ILog logger)
        {
            this.logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            logger.Information("Information has been logged at: " + DateTime.Now);
            logger.Warning("Warning has been logged at: " + DateTime.Now);
            logger.Debug("Debug has been logged at: " + DateTime.Now);
            logger.Error("Error has been logged at: " + DateTime.Now);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            logger.Debug("Debug has been logged at: " + DateTime.Now);
            logger.Error("Error has been logged at: " + DateTime.Now);
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
