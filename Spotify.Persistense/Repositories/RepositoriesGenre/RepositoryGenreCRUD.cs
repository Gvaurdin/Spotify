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
        public async Task AddAsync(Genre genre)
        {
            await spotifyDatabaseContext.AddAsync(genre);
            await spotifyDatabaseContext.SaveChangesAsync();
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
        public async Task<Genre> GetByIdAsync(int id) =>
            await spotifyDatabaseContext.Genres.SingleAsync(genre => genre.Id == id);
        public async Task RemoveAsync(int id)
        {
            await spotifyDatabaseContext.Genres.Where(genre => genre.Id == id).ExecuteDeleteAsync();
            await spotifyDatabaseContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, Genre genreNew)
        {
            await spotifyDatabaseContext.Genres.Where(genre => genre.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(genre => genre.Title, genreNew.Title)
            .SetProperty(genre => genre.Groups, genreNew.Groups));
        }
        public async Task<List<Genre>> GetGenresByIdsAsync(List<int> genreIds)
        {
            return await spotifyDatabaseContext.Genres
                .Where(gr => genreIds.Contains(gr.Id))
                .ToListAsync();
        }
    }
}
