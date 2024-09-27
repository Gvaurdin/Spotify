using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Commands.UpdateGroup
{
    public class UpdateGroupDTO : IMapWith<UpdateGroupCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGroupDTO, UpdateGroupCommand>()
                .ForMember(groupCommand => groupCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(groupCommand => groupCommand.Title,
                    opt => opt.MapFrom(groupDto => groupDto.Title))
                .ForMember(groupCommand => groupCommand.Description,
                    opt => opt.MapFrom(groupDto => groupDto.Description));
        }
    }
}
