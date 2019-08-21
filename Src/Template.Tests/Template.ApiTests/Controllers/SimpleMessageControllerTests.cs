using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Template.Domain.Models;
using Template.Domain.Services;
using Xunit;

namespace Template.Tests.Template.ApiTests.Controllers
{
    public class SimpleMessageControllerTests
    {
        private readonly Mock<ISimpleMessageService> _simpleMessageServiceMock;

        public SimpleMessageControllerTests()
        {

        }

        [Fact]
        public void Create_Success_ReturnsCreatedResultWithObject()
        {
            
        }
    }
}
