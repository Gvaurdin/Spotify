using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Queries.GetAlbumList
{
    public class AlbumLookUpDTO : IMapWith<Album>
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, AlbumLookUpDTO>()
                .ForMember(album => album.Id,
                opt => opt.MapFrom(album => album.Id))
                .ForMember(album => album.Title,
                opt => opt.MapFrom(album => album.Title));


        }
    }
}
