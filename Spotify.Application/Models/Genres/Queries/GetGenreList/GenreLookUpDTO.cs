using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Queries.GetGenreList
{
    public class GenreLookUpDTO : IMapWith<Genre>
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreLookUpDTO>()
                .ForMember(genre => genre.Id,
                opt => opt.MapFrom(genre => genre.Id))
                .ForMember(genre => genre.Title,
                opt => opt.MapFrom(genre => genre.Title));
        }
    }
}
