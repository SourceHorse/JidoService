using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Moq;
using Template.Api.Controllers;
using Template.Domain.Models;
using Template.Domain.Services;
using Xunit;

namespace Template.Tests.Template.ApiTests.Controllers
{
    public class SimpleMessageControllerTests
    {
        private readonly SimpleMessageController _controller;
        private readonly Mock<ISimpleMessageService> _simpleMessageServiceMock;
        private readonly Mock<IValidator<SimpleMessageCreateRequest>> _simpleMessageCreateRequestMock;
        private readonly Mock<IValidator<SimpleMessageUpdateRequest>> _simpleMessageUpdateRequestMock;

        public SimpleMessageControllerTests()
        {
            _controller = new SimpleMessageController()
            {

            }
        }

        [Fact]
        public void Create_Success_ReturnsCreatedResultWithObject()
        {
            
        }
    }
}
