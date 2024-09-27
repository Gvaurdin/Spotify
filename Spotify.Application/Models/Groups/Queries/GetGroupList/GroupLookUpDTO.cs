using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Queries.GetGroupList
{
    public class GroupLookUpDTO : IMapWith<Group>
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupLookUpDTO>()
                .ForMember(group => group.Id,
                opt => opt.MapFrom(group => group.Id))
                .ForMember(group => group.Title,
                opt => opt.MapFrom(group => group.Title));


        }
    }
}
