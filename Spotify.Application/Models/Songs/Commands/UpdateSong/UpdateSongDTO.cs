using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Commands.UpdateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.UpdateSong
{
    public class UpdateSongDTO: IMapWith<UpdateSongCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSongDTO, UpdateSongCommand>()
                .ForMember(songCommand => songCommand.Id,
                    opt => opt.MapFrom(songDto => songDto.Id))
                .ForMember(songCommand => songCommand.Title,
                    opt => opt.MapFrom(songDto => songDto.Title))
                .ForMember(songCommand => songCommand.Description,
                    opt => opt.MapFrom(songDto => songDto.Description));
        }
    }
}
