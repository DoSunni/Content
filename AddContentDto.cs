using AutoMapper;
using Contents.Application.Common.Mappings;
using Contents.Application.Contents.Commands.AddContent;
using System.ComponentModel.DataAnnotations;

namespace Contents.WebApi.Models
{
    public class AddContentDto : IMapWith<AddContentCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddContentDto, AddContentCommand>()
                .ForMember(contentCommand => contentCommand.Title,
                opt => opt.MapFrom(contentDto => contentDto.Title))
                .ForMember(contentCommand => contentCommand.Format,
                opt => opt.MapFrom(contentDto => contentDto.Format))
                .ForMember(contentCommand => contentCommand.Description,
                opt => opt.MapFrom(contentDto => contentDto.Description));
        }
    }
}
