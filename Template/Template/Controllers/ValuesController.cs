using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Template.Infrastructure.Couchbase;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICouchbase _couchbase;

        public ValuesController(ICouchbase couchbase)
        {
            _couchbase = couchbase;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
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

        // Get api/values
        [HttpGet("InsertCouchbase")]
        public IActionResult InsertCouchbase()
        {
            _couchbase.AddTestValue();

            return Ok("done");
        }
    }
}
