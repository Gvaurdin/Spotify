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
        Task AddAsync(Genre genre, CancellationToken cancellationToken);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByTitleAsync(string title);
        Task<List<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task RemoveAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(int id, Genre genreNew, CancellationToken cancellationToken);
        Task<List<Genre>> GetGenresByIdsAsync(List<int> genreIds);
    }
}
