using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongList
{
    public class SongLookUpDTO : IMapWith<Song>
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongLookUpDTO>()
                .ForMember(song => song.Id,
                opt => opt.MapFrom(song => song.Id))
                .ForMember(song => song.Title,
                opt => opt.MapFrom(song => song.Title));


        }
    }
}
