using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Repositories.RepositoriesGenre
{
    public interface IRepositoryGenreCRUD
    {
        Task AddAsync(Genre genre);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByTitleAsync(string title);
        Task<List<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, Genre genreNew);
        Task<List<Genre>> GetGenresByIdsAsync(List<int> genreIds);
    }
}
