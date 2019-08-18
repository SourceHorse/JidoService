using System;
using Microsoft.AspNetCore.Mvc;
using Template.Domain.Models;
using Template.Domain.Services;

namespace Template.Api.Controllers
{
    [Route("SimpleMessage")]
    [ApiController]
    public class SimpleMessageController
    {
        private readonly ISimpleMessageService _simpleMessageService;

        public SimpleMessageController(ISimpleMessageService simpleMessageService)
        {
            _simpleMessageService = simpleMessageService ?? throw new ArgumentNullException(nameof(simpleMessageService));
        }

        // POST /SimpleMessage
        [HttpPost]
        public IActionResult Create([FromBody] SimpleMessageCreateRequest simpleMessageCreate)
        {
            var savedDocument = _simpleMessageService.AddMessage(simpleMessageCreate);

            return new CreatedResult("/SimpleMessage", savedDocument);
        }

        // GET /SimpleMessage/{id}
        [HttpGet("{id}")]
        public IActionResult Read([FromRoute] string id)
        {
            var retrievedDocument = _simpleMessageService.RetrieveMessage(new Guid(id));
            if (retrievedDocument == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(retrievedDocument);
        }

        // PUT /SimpleMessage/{id}
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] string id, [FromBody] SimpleMessage simpleMessage)
        {
            var updatedDocument = _simpleMessageService.UpdateMessage(new Guid(id), simpleMessage);

            if (updatedDocument == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(updatedDocument);
        }

        // DELETE /SimpleMessage/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            _simpleMessageService.DeleteMessage(new Guid(id));

            return new OkResult();
        }
    }
}
