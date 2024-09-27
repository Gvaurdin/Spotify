using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Repositories.RepositoriesSong
{
    public interface IRepositorySongCRUD
    {
        Task AddAsync(Song song);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByTitleAsync(string title);
        Task<List<Song>> GetAllAsync();
        Task<Song> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, Song songNew);
        Task<List<Song>> GetSongsByIdsAsync(List<int> songIds);
    }
}
