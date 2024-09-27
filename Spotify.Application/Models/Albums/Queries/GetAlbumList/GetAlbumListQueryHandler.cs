using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using Spotify.Application.Repositories.RepositoriesAlbum;
using Spotify.Application.Repositories.RepositoriesGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Queries.GetAlbumList
{
    public class GetAlbumListQueryHandler(IMapper mapper, IRepositoryAlbumCRUD repositoryAlbumCRUD) : IRequestHandler<GetAlbumListQuery, AlbumListViewModel>
    {
        public async Task<AlbumListViewModel> Handle(GetAlbumListQuery request, CancellationToken cancellationToken)
        {
            var albums = await repositoryAlbumCRUD.GetAllAsync();

            var projectedAlbums = albums
                .AsQueryable()
                .ProjectTo<AlbumLookUpDTO>(mapper.ConfigurationProvider)
                .Skip(request.CountSkipAlbums)
                .Take(request.TakeAlbums)
                .ToList();

            return new AlbumListViewModel
            {
                Albums = projectedAlbums
            };
        }
    }
}
