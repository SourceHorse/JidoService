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

namespace Template.Tests.Template.ApiTests.Controllers
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
            var messageCreateObject = new SimpleMessageCreateRequest()
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
            var result = await _controller.Create(messageCreateObject);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }
    }
}
