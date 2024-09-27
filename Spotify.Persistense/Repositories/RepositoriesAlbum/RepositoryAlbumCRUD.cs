using Microsoft.EntityFrameworkCore;
using Spotify.Application.Repositories.RepositoriesAlbum;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Persistense.Repositories.RepositoriesAlbum
{
    public class RepositoryAlbumCRUD(SpotifyDatabaseContext spotifyDatabaseContext) : IRepositoryAlbumCRUD
    {
        public async Task AddAsync(Album album, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.AddAsync(album, cancellationToken);
            await spotifyDatabaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await spotifyDatabaseContext.Albums.AnyAsync(album => album.Id == id);
        }
        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await spotifyDatabaseContext.Albums.AnyAsync(album => album.Title == title);
        }
        public async Task<List<Album>> GetAllAsync()
        {
            return await spotifyDatabaseContext.Albums
                .Include(album => album.Songs)
                .Include(album => album.Groups)
                .ToListAsync();
        }
        public async Task<Album> GetByIdAsync(int id, CancellationToken cancellationToken) =>
            await spotifyDatabaseContext.Albums.SingleAsync(album => album.Id == id, cancellationToken);
        public async Task<List<Album>> GetAlbumsByIdsAsync(List<int> albumIds)
        {
            return await spotifyDatabaseContext.Albums
                   .Where(a => albumIds.Contains(a.Id)).ToListAsync();
        }
        public async Task RemoveAsync(int id, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.Albums.Where(album => album.Id == id).ExecuteDeleteAsync(cancellationToken);
            await spotifyDatabaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(int id, Album albumNew, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.Albums.Where(album => album.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(album => album.Title, albumNew.Title)
            .SetProperty(album => album.Description, albumNew.Description)
            .SetProperty(album => album.ReleaseDate, albumNew.ReleaseDate), cancellationToken);
        }

    }
}
