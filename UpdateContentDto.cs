using System;
using AutoMapper;
using Contents.Application.Common.Mappings;
using Contents.Application.Contents.Commands.UpdateContent;

namespace Contents.WebApi.Models
{
    public class UpdateContentDto : IMapWith<UpdateContentCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContentDto, UpdateContentCommand>()
                .ForMember(contentCommand => contentCommand.Id,
                opt => opt.MapFrom(contentDto => contentDto.Id))
                .ForMember(contentCommand => contentCommand.Title,
                opt => opt.MapFrom(contentDto => contentDto.Title))
                .ForMember(contentCommand => contentCommand.Format,
                opt => opt.MapFrom(contentDto => contentDto.Format))
                .ForMember(contentCommand => contentCommand.Description,
                opt => opt.MapFrom(contentDto => contentDto.Description));
        }

    }
}
