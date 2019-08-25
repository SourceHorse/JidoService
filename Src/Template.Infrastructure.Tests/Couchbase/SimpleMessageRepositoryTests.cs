using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Couchbase.Core;
using Couchbase;
using Moq;
using Template.Domain.Couchbase;
using Template.Domain.Models;
using Template.Infrastructure.Couchbase;
using Template.Infrastructure.Couchbase.Models;
using Xunit;

namespace Template.Infrastructure.Tests.Couchbase
{
    public class SimpleMessageRepositoryTests
    {
        private readonly SimpleMessageRepository _repository;
        private readonly Mock<IBucket> _bucketMock = new Mock<IBucket>();
        private readonly Mock<ITestBucketProvider> _testBucketProviderMock = new Mock<ITestBucketProvider>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public SimpleMessageRepositoryTests()
        {
            _repository = new SimpleMessageRepository(_testBucketProviderMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task AddMessage_ReturnsSimpleMessage()
        {
            // Arrange
            var responseTask = Task.FromResult((IOperationResult<SimpleMessageDbModel>)new SimpleMessageDbModel());
            _bucketMock.Setup(x => x.InsertAsync(It.IsAny<string>(), It.IsAny<SimpleMessageDbModel>()));
            _bucketMock.Setup(x => x.GetAsync<SimpleMessageDbModel>(It.IsAny<string>())).Returns(responseTask);
            _mapperMock.Setup(x => x.Map<SimpleMessageDbModel>(It.IsAny<SimpleMessageCreateRequest>())).Returns(new SimpleMessageDbModel());
            _mapperMock.Setup(x => x.Map<SimpleMessage>(It.IsAny<SimpleMessageDbModel>())).Returns(new SimpleMessage());

            // Act
            var result = await _repository.AddMessage(new SimpleMessageCreateRequest());
        }
    }
}
