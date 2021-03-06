using System.Threading.Tasks;
using AutoMapper;
using Couchbase.Core;
using Couchbase;
using Moq;
using Jido.Domain.Models;
using Jido.Infrastructure.Couchbase;
using Jido.Infrastructure.Couchbase.Models;
using Xunit;

namespace Jido.Infrastructure.Tests.Couchbase
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
            var simpleMessageOperationResult = new Mock<IOperationResult<SimpleMessageDbModel>>().Object;
            var responseTask = Task.FromResult((IOperationResult<SimpleMessageDbModel>)simpleMessageOperationResult);
            _bucketMock.Setup(x => x.InsertAsync(It.IsAny<string>(), It.IsAny<SimpleMessageDbModel>()));
            _bucketMock.Setup(x => x.GetAsync<SimpleMessageDbModel>(It.IsAny<string>())).Returns(responseTask);
            _mapperMock.Setup(x => x.Map<SimpleMessageDbModel>(It.IsAny<SimpleMessageCreateRequest>())).Returns(new SimpleMessageDbModel());
            _mapperMock.Setup(x => x.Map<SimpleMessage>(It.IsAny<SimpleMessageDbModel>())).Returns(new SimpleMessage());
            _testBucketProviderMock.Setup(x => x.GetBucket()).Returns(_bucketMock.Object);

            // Act
            var result = await _repository.AddMessage(new SimpleMessageCreateRequest());

            // Assert
            Assert.IsType<SimpleMessage>(result);
        }
    }
}
