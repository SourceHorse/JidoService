using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Template.Domain.Models;
using Template.Infrastructure.Couchbase.Models;

namespace Template.Infrastructure
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
