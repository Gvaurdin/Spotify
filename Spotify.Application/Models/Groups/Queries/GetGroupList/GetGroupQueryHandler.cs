using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Application.Repositories.RepositoriesGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Queries.GetGroupList
{
    public class GetGroupQueryHandler(IMapper mapper,IRepositoryGroupCRUD repositoryGroupCRUD) : IRequestHandler<GetGroupListQuery, GroupListViewModel>
    {
        public async Task<GroupListViewModel> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            var groups = await repositoryGroupCRUD.GetAllAsync();

            // проекция к GroupLookUpDTO с помощью AutoMapper
            var projectedGroups = groups
                .AsQueryable() // преобразование в IQueryable для использования ProjectTo
                .ProjectTo<GroupLookUpDTO>(mapper.ConfigurationProvider)
                .Skip(request.CountSkipGroups)
                .Take(request.TakeGroups)
                .ToList();

            return new GroupListViewModel
            {
                Groups = projectedGroups
            };
        }
    }
}
