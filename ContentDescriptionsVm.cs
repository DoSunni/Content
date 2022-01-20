using System;
using AutoMapper;
using Contents.Application.Common.Mappings;
using Contents.Domain;

namespace Contents.Application.Contents.Queries.GetContentDescriptions
{
    public class ContentDescriptionsVm : IMapWith<File>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<File, ContentDescriptionsVm>()
                .ForMember(contentVm => contentVm.Title,
                    opt => opt.MapFrom(content => content.Title))
                .ForMember(contentVm => contentVm.Description,
                    opt => opt.MapFrom(content => content.Description))
                .ForMember(contentVm => contentVm.Id,
                    opt => opt.MapFrom(content => content.Id))
                .ForMember(contentVm => contentVm.Created,
                    opt => opt.MapFrom(content => content.Created))
                .ForMember(contentVm => contentVm.Updated,
                    opt => opt.MapFrom(content => content.Updated));
        }

    }
}
