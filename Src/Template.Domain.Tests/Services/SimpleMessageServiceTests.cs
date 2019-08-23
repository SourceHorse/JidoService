using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Template.Domain.Couchbase;
using Template.Domain.Services;
using Xunit;

namespace Template.Domain.Tests.Services
{
    class SimpleMessageServiceTests
    {
        private readonly ISimpleMessageService _service;
        private readonly Mock<ISimpleMessageRepository> _simpleMessageRepositoryMock = new Mock<ISimpleMessageRepository>();
    }
}
