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
    public class SongDetailsViewModel: IMapWith<Song>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongDetailsViewModel>()
                //.ForMember(songVM => songVM.Id, opt => opt.MapFrom(song => song.Id))
                .ForMember(songVM => songVM.Title, opt => opt.MapFrom(song => song.Title))
                .ForMember(songVM => songVM.Description, opt => opt.MapFrom(song => song.Description));
        }
    }
}
