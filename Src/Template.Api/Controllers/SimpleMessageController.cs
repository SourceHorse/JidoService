using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Template.Domain.Models;
using Template.Infrastructure.Couchbase;

namespace Template.Api.Controllers
{
    [Route("SimpleMessage")]
    [ApiController]
    public class SimpleMessageController
    {

        // POST /simplemessage
        [HttpPost]
        public IActionResult Create([FromBody] SimpleMessage simpleMessage)
        {

            return Create(simpleMessage);
        }
    }
}
