using System;
using System.Threading.Tasks;
using FluentValidation;
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
        private readonly IValidator _validator;

        public SimpleMessageController(ISimpleMessageService simpleMessageService, IValidator validator)
        {
            _simpleMessageService = simpleMessageService ?? throw new ArgumentNullException(nameof(simpleMessageService));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        // POST /SimpleMessage
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SimpleMessageCreateRequest simpleMessageCreate)
        {
            _validator.Validate(simpleMessageCreate);
            var savedDocument = await _simpleMessageService.AddMessage(simpleMessageCreate);

            return new CreatedResult("/SimpleMessage", savedDocument);
        }

        // GET /SimpleMessage/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] string id)
        {
            var retrievedDocument = await _simpleMessageService.RetrieveMessage(new Guid(id));
            if (retrievedDocument == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(retrievedDocument);
        }

        // PUT /SimpleMessage/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] SimpleMessageUpdateRequest simpleMessageUpdate)
        {
            _validator.Validate(simpleMessageUpdate);
            var updatedDocument = await _simpleMessageService.UpdateMessage(new Guid(id), simpleMessageUpdate);

            if (updatedDocument == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(updatedDocument);
        }

        // DELETE /SimpleMessage/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _simpleMessageService.DeleteMessage(new Guid(id));

            return new OkResult();
        }
    }
}
