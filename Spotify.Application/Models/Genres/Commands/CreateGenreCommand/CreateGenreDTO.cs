using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Application.Models.Groups.Commands.CreateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.CreateGenreCommand
{
    public class CreateGenreDTO: IMapWith<CreateGenreCommand>
    {
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGenreDTO, CreateGenreCommand>()
                .ForMember(genrecommand => genrecommand.Title,
                opt => opt.MapFrom(genreDto => genreDto.Title));

        }
    }
}
