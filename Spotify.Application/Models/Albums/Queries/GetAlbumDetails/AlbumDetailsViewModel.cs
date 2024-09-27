using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Queries.GetGroupDetails;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Queries.GetAlbumDetails
{
    public class AlbumDetailsViewModel: IMapWith<Album>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, AlbumDetailsViewModel>()
                //.ForMember(albumVM => albumVM.Id, opt => opt.MapFrom(album => album.Id))
                .ForMember(albumVM => albumVM.Title, opt => opt.MapFrom(album => album.Title))
                .ForMember(albumVM => albumVM.Description, opt => opt.MapFrom(album => album.Description));
        }
    }
}
