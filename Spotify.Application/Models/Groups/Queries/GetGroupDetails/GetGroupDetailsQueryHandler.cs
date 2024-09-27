using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Spotify.Application.Exceptions;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Queries.GetGroupDetails
{
    public class GetGroupDetailsQueryHandler(IRepositoryGroupCRUD repositoryGroupCRUD, IMapper mapper) : IRequestHandler<GetGroupDetailsQuery, GroupDetailsViewModel>
    {
        public async Task<GroupDetailsViewModel> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
        {
            var projectGroup = await repositoryGroupCRUD.GetByIdAsync(request.Id,cancellationToken) ??
                throw new NotFoundException(nameof(Group), request.Id);
            return mapper.Map<GroupDetailsViewModel>(projectGroup);
        }
    }
}
