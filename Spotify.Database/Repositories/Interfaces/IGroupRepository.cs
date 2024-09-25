using Spotify.Database.Data;
using Spotify.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Database.Repositories.Interfaces
{
    public interface IGroupRepository
    {

        Task AddAsync(Group group);

        Task<List<Group>> GetAllAsync();

        Task<Group> GetByIdAsync(int id);

        Task RemoveAsync(int id);

        Task UpdateAsync(int id, Group groupNew);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByTitleAsync(string title);
        Task<List<Group>> GetGroupsByIdsAsync(List<int> groupIds);
    }
}
