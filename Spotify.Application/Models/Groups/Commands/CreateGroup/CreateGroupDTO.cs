using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Commands.CreateGroup
{
    public class CreateGroupDTO : IMapWith<CreateGroupCommand>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGroupDTO, CreateGroupCommand>()
                .ForMember(groupcommand => groupcommand.Title,
                opt => opt.MapFrom(groupDto => groupDto.Title))
                .ForMember(groupcommand => groupcommand.Description,
                opt => opt.MapFrom(groupDto => groupDto.Description));

        }
    }
}
