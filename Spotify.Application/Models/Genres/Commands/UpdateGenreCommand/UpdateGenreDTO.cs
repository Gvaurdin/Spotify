using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Commands.UpdateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.UpdateGenreCommand
{
    public class UpdateGenreDTO: IMapWith<UpdateGenreCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGenreDTO, UpdateGenreCommand>()
                .ForMember(genreCommand => genreCommand.Id,
                    opt => opt.MapFrom(genre => genre.Id))
                .ForMember(genreCommand => genreCommand.Title,
                    opt => opt.MapFrom(genre => genre.Title));
        }
    }
}
