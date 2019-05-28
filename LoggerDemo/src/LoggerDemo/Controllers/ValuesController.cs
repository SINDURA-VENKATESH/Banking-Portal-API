using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace LoggerDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        ILoggerFactory _loggerFactory;

        public ValuesController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var logger = _loggerFactory.CreateLogger("LoggerCategory");
            logger.LogInformation("Calling the get action");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
