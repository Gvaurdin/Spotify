using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Repositories.RepositoriesAlbum
{
    public interface IRepositoryAlbumCRUD
    {
        Task AddAsync(Album album, CancellationToken cancellationToken);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByTitleAsync(string title);
        Task<List<Album>> GetAllAsync();
        Task<Album> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task RemoveAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(int id, Album albumNew, CancellationToken cancellationToken);
        Task<List<Album>> GetAlbumsByIdsAsync(List<int> albumIds);
    }
}
