using System;
using AutoMapper;
using Contents.Domain;
using Contents.Application.Common.Mappings;

namespace Contents.Application.Contents.Queries.GetContentList
{
    public class ContentLookupDto : IMapWith<File>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<File, ContentLookupDto>()
                .ForMember(contentDto => contentDto.Id,
                opt => opt.MapFrom(content => content.Id))
                .ForMember(contentDto => contentDto.Title,
                opt => opt.MapFrom(content => content.Title));
        }
    }
}
