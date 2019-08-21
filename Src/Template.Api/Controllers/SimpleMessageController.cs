using System;
using System.Linq;
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
        private readonly IValidator<SimpleMessageCreateRequest> _createValidator;
        private readonly IValidator<SimpleMessageUpdateRequest> _updateValidator;

        public SimpleMessageController(
            ISimpleMessageService simpleMessageService, 
            IValidator<SimpleMessageCreateRequest> createValidator,
            IValidator<SimpleMessageUpdateRequest> updateValidator)
        {
            _simpleMessageService = simpleMessageService ?? throw new ArgumentNullException(nameof(simpleMessageService));
            _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
            _updateValidator = updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));
        }

        // POST /SimpleMessage
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SimpleMessageCreateRequest simpleMessageCreate)
        {
            var validationResult = await _createValidator.ValidateAsync(simpleMessageCreate);
            if (!validationResult.IsValid)
            {
                return FailValidation(validationResult);
            }

            var savedDocument = await _simpleMessageService.AddMessage(simpleMessageCreate);

            return new CreatedResult("/SimpleMessage", savedDocument);
        }

        // GET /SimpleMessage/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] string id)
        {
            if (!IsValidGuid(id))
            {
                return new NotFoundResult();
            }

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
            if (!IsValidGuid(id))
            {
                return new NotFoundResult();
            }

            var validationResult = await _updateValidator.ValidateAsync(simpleMessageUpdate);
            if (!validationResult.IsValid)
            {
                return FailValidation(validationResult);
            }

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
            if (!IsValidGuid(id))
            {
                return new NotFoundResult();
            }

            await _simpleMessageService.DeleteMessage(new Guid(id));

            return new OkResult();
        }

        private IActionResult FailValidation(FluentValidation.Results.ValidationResult validationResult)
        {
            var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return new BadRequestObjectResult(errorMessages);
        }

        private bool IsValidGuid(string str)
        {
            try
            {
                new Guid(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
