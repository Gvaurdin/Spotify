using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Repositories.RepositoriesGroup
{
    public interface IRepositoryGroupCRUD
    {
        Task AddAsync(Group group, CancellationToken cancellationToken);
        Task<List<Group>> GetAllAsync();
        Task<Group> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task RemoveAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(int id, Group groupNew, CancellationToken cancellationToken);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByTitleAsync(string title);
        Task<List<Group>> GetGroupsByIdsAsync(List<int> groupIds);
    }
}
