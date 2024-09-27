using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.DTO;
using Spotify.Application.Models.Groups.Commands.UpdateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumDTO: IMapWith<UpdateAlbumCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAlbumDTO, UpdateAlbumCommand>()
                .ForMember(albumCommand => albumCommand.Id,
                    opt => opt.MapFrom(albumDto => albumDto.Id))
                .ForMember(albumCommand => albumCommand.Title,
                    opt => opt.MapFrom(albumDto => albumDto.Title))
                .ForMember(albumCommand => albumCommand.Description,
                    opt => opt.MapFrom(albumDto => albumDto.Description));
        }
    }
}
