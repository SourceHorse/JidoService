using System;
using AutoMapper;
using Jido.Domain.Models;
using Jido.Infrastructure.Couchbase.Models;

namespace Jido.Infrastructure
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SimpleMessage, SimpleMessageDbModel>();
            CreateMap<SimpleMessageDbModel, SimpleMessage>();
            CreateMap<SimpleMessageCreateRequest, SimpleMessageDbModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => true));
            CreateMap<SimpleMessageUpdateRequest, SimpleMessageDbModel>();
        }
    }
}
