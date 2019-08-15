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

        // POST /simplemessage
        [HttpPost]
        public IActionResult Create([FromBody] SimpleMessage simpleMessage)
        {
            var savedDocument = _simpleMessageService.AddMessage(simpleMessage);

            return new CreatedResult("/SimpleMessage", savedDocument);
        }
    }
}
