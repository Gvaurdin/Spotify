using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Application.Repositories.RepositoriesSong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongList
{
    public class GetSongListQueryHandler(IMapper mapper, IRepositorySongCRUD repositorySongCRUD) : IRequestHandler<GetSongListQuery, SongListViewModel>
    {
        public async Task<SongListViewModel> Handle(GetSongListQuery request, CancellationToken cancellationToken)
        {
            var songs = await repositorySongCRUD.GetAllAsync();

            var projectedSongs = songs
                .AsQueryable()
                .ProjectTo<SongLookUpDTO>(mapper.ConfigurationProvider)
                .Skip(request.CountSkipSongs)
                .Take(request.TakeSongs)
                .ToList();

            return new SongListViewModel
            {
                Songs = projectedSongs
            };
        }
    }
}
