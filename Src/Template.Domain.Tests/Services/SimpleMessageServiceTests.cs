using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Template.Domain.Couchbase;
using Template.Domain.Models;
using Template.Domain.Services;
using Template.Domain.Services.Impl;
using Template.Infrastructure.Couchbase;
using Xunit;

namespace Template.Domain.Tests.Services
{
    public class SimpleMessageServiceTests
    {
        private readonly SimpleMessageService _service;
        private readonly Mock<ISimpleMessageRepository> _simpleMessageRepositoryMock = new Mock<ISimpleMessageRepository>();

        public SimpleMessageServiceTests()
        {
            _service = new SimpleMessageService(_simpleMessageRepositoryMock.Object);
        }

        [Fact]
        public async Task AddMessage_ReturnsSimpleMessage()
        {
            // Arrange
            _simpleMessageRepositoryMock.Setup(x => x
                .AddMessage(It.IsAny<SimpleMessageCreateRequest>()))
                .ReturnsAsync(new SimpleMessage());

            // Act
            var result = await _service.AddMessage(new SimpleMessageCreateRequest());

            // Assert
            Assert.IsType<SimpleMessage>(result);
        }
    }
}
