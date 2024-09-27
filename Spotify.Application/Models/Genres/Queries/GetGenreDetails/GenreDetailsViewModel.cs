using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Queries.GetGroupDetails;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongDetails
{
    public class GenreDetailsViewModel: IMapWith<Genre>
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreDetailsViewModel>()
                //.ForMember(genreVM => genreVM.Id, opt => opt.MapFrom(genre => genre.Id))
                .ForMember(genreVM => genreVM.Title, opt => opt.MapFrom(genre => genre.Title));
        }
    }
}
