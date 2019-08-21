using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Template.Api.Controllers;
using Template.Domain.Models;
using Template.Domain.Services;
using Xunit;

namespace Template.Api.Tests.Controllers
{
    public class SimpleMessageControllerTests
    {
        private readonly SimpleMessageController _controller;
        private readonly Mock<ISimpleMessageService> _simpleMessageServiceMock = new Mock<ISimpleMessageService>();
        private readonly Mock<IValidator<SimpleMessageCreateRequest>> _createValidatorMock = new Mock<IValidator<SimpleMessageCreateRequest>>();
        private readonly Mock<IValidator<SimpleMessageUpdateRequest>> _updateValidatorMock = new Mock<IValidator<SimpleMessageUpdateRequest>>();

        public SimpleMessageControllerTests()
        {
            _controller = new SimpleMessageController(
                _simpleMessageServiceMock.Object,
                _createValidatorMock.Object,
                _updateValidatorMock.Object);
        }

        [Fact]
        public async Task Create_Success_ReturnsCreatedResult()
        {
            // Arrange
            var messageCreateMock = new SimpleMessageCreateRequest()
            {
                Title = "Test Title",
                Body = "Test Body"
            };
            _createValidatorMock.Setup(
                x => x.ValidateAsync(
                    It.IsAny<SimpleMessageCreateRequest>(), 
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new FluentValidation.Results.ValidationResult());
            _simpleMessageServiceMock.Setup(
                x => x.AddMessage(
                    It.IsAny<SimpleMessageCreateRequest>()))
                    .ReturnsAsync(new SimpleMessage());

            // Act
            var result = await _controller.Create(messageCreateMock);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task Create_ValidationFailure_ReturnsBadRequestObjectResult()
        {
            // Arrange
            var messageCreateMock = new SimpleMessageCreateRequest()
            {
                Title = "",
                Body = "Test Body"
            };
            var validationFailures = new List<FluentValidation.Results.ValidationFailure> {
                new FluentValidation.Results.ValidationFailure("Title", "Title cannot be empty")
            };
            _createValidatorMock.Setup(
                x => x.ValidateAsync(
                    It.IsAny<SimpleMessageCreateRequest>(),
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new FluentValidation.Results.ValidationResult(validationFailures));
            _simpleMessageServiceMock.Setup(
                x => x.AddMessage(
                    It.IsAny<SimpleMessageCreateRequest>()))
                    .ReturnsAsync(new SimpleMessage());

            // Act
            var result = await _controller.Create(messageCreateMock);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Read_Success_ReturnsOkObjectResult()
        {
            // Arrange
            var idMock = Guid.NewGuid().ToString();
            _simpleMessageServiceMock.Setup(x => x.RetrieveMessage(It.IsAny<Guid>())).ReturnsAsync(new SimpleMessage());

            // Act
            var result = await _controller.Read(idMock);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Read_NotFound_ReturnsNotFoundResult()
        {
            // Arrange
            var idMock = Guid.NewGuid().ToString();
            _simpleMessageServiceMock.Setup(x => x.RetrieveMessage(It.IsAny<Guid>())).ReturnsAsync((SimpleMessage)null);

            // Act
            var result = await _controller.Read(idMock);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Read_InvalidGuid_ReturnsNotFoundResult()
        {
            // Arrange
            var idMock = "1";
            _simpleMessageServiceMock.Setup(x => x.RetrieveMessage(It.IsAny<Guid>())).ReturnsAsync((SimpleMessage)null);

            // Act
            var result = await _controller.Read(idMock);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
