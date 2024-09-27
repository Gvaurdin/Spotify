using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Commands.CreateGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.CreateSong
{
    public class CreateSongDTO: IMapWith<CreateSongCommand>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSongDTO, CreateSongCommand>()
                .ForMember(songcommand => songcommand.Title,
                opt => opt.MapFrom(songDto => songDto.Title))
                .ForMember(songcommand => songcommand.Description,
                opt => opt.MapFrom(songDto => songDto.Description));

        }
    }
}
