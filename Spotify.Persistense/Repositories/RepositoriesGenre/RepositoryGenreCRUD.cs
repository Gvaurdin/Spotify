using Microsoft.EntityFrameworkCore;
using Spotify.Application.Repositories.RepositoriesGenre;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Persistense.Repositories.RepositoriesGenre
{
    public class RepositoryGenreCRUD(SpotifyDatabaseContext spotifyDatabaseContext): IRepositoryGenreCRUD
    {
        public async Task AddAsync(Genre genre, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.AddAsync(genre, cancellationToken);
            await spotifyDatabaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await spotifyDatabaseContext.Genres.AnyAsync(genre => genre.Id == id);
        }
        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await spotifyDatabaseContext.Genres.AnyAsync(genre => genre.Title == title);
        }
        public async Task<List<Genre>> GetAllAsync() =>
            await spotifyDatabaseContext.Genres
            .Include(genre => genre.Groups)
            .ToListAsync();
        public async Task<Genre> GetByIdAsync(int id, CancellationToken cancellationToken) =>
            await spotifyDatabaseContext.Genres.SingleAsync(genre => genre.Id == id, cancellationToken);
        public async Task RemoveAsync(int id, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.Genres.Where(genre => genre.Id == id).ExecuteDeleteAsync(cancellationToken);
            await spotifyDatabaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(int id, Genre genreNew, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.Genres.Where(genre => genre.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(genre => genre.Title, genreNew.Title), cancellationToken);
        }
        public async Task<List<Genre>> GetGenresByIdsAsync(List<int> genreIds)
        {
            return await spotifyDatabaseContext.Genres
                .Where(gr => genreIds.Contains(gr.Id))
                .ToListAsync();
        }
    }
}
