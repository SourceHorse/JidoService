using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Couchbase.Core;
using Moq;
using Template.Domain.Couchbase;
using Template.Domain.Models;
using Template.Infrastructure.Couchbase;
using Xunit;

namespace Template.Infrastructure.Tests.Couchbase
{
    public class SimpleMessageRepositoryTests
    {
        private readonly SimpleMessageRepository _repository;
        private readonly Mock<ITestBucketProvider> _bucketMock = new Mock<ITestBucketProvider>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public SimpleMessageRepositoryTests()
        {
            _repository = new SimpleMessageRepository(_bucketMock.Object, _mapperMock.Object);
        }
    }
}
