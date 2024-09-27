using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Commands.CreateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.CreateAlbum
{
    public class CreateAlbumDTO: IMapWith<CreateAlbumCommand>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAlbumDTO, CreateAlbumCommand>()
                .ForMember(albumcommand => albumcommand.Title,
                opt => opt.MapFrom(albumDto => albumDto.Title))
                .ForMember(albumcommand => albumcommand.Description,
                opt => opt.MapFrom(albumDto => albumDto.Description));

        }
    }
}
