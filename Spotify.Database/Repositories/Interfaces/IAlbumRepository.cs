﻿using Spotify.Database.Data;
using Spotify.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Database.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Task AddAsync(Album album);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByTitleAsync(string title);
        Task<List<Album>> GetAllAsync();
        Task<Album> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, Album albumNew);
        Task<List<Album>> GetAlbumsByIdsAsync(List<int> albumIds);
    }
}
