using AutoMapper;
using Spotify.Application.Common.MappingProfile;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Groups.Queries.GetGroupDetails
{
    public class GroupDetailsViewModel : IMapWith<Group>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupDetailsViewModel>()
                .ForMember(groupVM => groupVM.Id, opt => opt.MapFrom(group => group.Id))
                .ForMember(groupVM => groupVM.Title, opt => opt.MapFrom(group => group.Title))
                .ForMember(groupVM => groupVM.Description, opt => opt.MapFrom(group => group.Description));
        }
    }
}
