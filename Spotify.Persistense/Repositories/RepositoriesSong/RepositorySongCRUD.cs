using Microsoft.EntityFrameworkCore;
using Spotify.Application.Repositories.RepositoriesSong;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Persistense.Repositories.RepositoriesSong
{
    public class RepositorySongCRUD(SpotifyDatabaseContext spotifyDatabaseContext) : IRepositorySongCRUD
    {
        public async Task AddAsync(Song song, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.AddAsync(song, cancellationToken);
            await spotifyDatabaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await spotifyDatabaseContext.Songs.AnyAsync(song => song.Id == id);
        }
        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await spotifyDatabaseContext.Songs.AnyAsync(song => song.Title == title);
        }
        public async Task<List<Song>> GetAllAsync()
        {
            return await spotifyDatabaseContext.Songs
                .Include(song => song.Albums)
                .ToListAsync();
        }
        public async Task<Song> GetByIdAsync(int id,CancellationToken cancellationToken) =>
            await spotifyDatabaseContext.Songs.SingleAsync(song => song.Id == id, cancellationToken);
        public async Task RemoveAsync(int id, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.Songs.Where(song => song.Id == id).ExecuteDeleteAsync(cancellationToken);
            await spotifyDatabaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(int id, Song songNew,CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.Songs.Where(song => song.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(song => song.Title, songNew.Title)
            .SetProperty(song => song.Description, songNew.Description), cancellationToken);
        }
        public async Task<List<Song>> GetSongsByIdsAsync(List<int> songIds)
        {
            return await spotifyDatabaseContext.Songs
                .Where(song => songIds.Contains(song.Id))
                .ToListAsync();
        }
    }
}
