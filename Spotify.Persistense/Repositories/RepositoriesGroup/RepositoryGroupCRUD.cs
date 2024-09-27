using Microsoft.EntityFrameworkCore;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Persistense.Repositories.RepositoriesGroup
{
    public class RepositoryGroupCRUD(SpotifyDatabaseContext spotifyDatabaseContext) : IRepositoryGroupCRUD
    {
        public async Task AddAsync(Group group, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.AddAsync(group, cancellationToken);
            await spotifyDatabaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await spotifyDatabaseContext.Groups.AnyAsync(group => group.Id == id);
        }
        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await spotifyDatabaseContext.Groups.AnyAsync(group => group.Title == title);
        }
        public async Task<List<Group>> GetAllAsync()
        {
            return await spotifyDatabaseContext.Groups
                .Include(group => group.Genres)
                .Include(group => group.Albums)
                .ToListAsync();
        }
        public async Task<Group> GetByIdAsync(int id, CancellationToken cancellationToken) =>
            await spotifyDatabaseContext.Groups.SingleAsync(group => group.Id == id, cancellationToken);
        public async Task RemoveAsync(int id, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.Groups.Where(group => group.Id == id).ExecuteDeleteAsync(cancellationToken);
            await spotifyDatabaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(int id, Group groupNew, CancellationToken cancellationToken)
        {
            await spotifyDatabaseContext.Groups.Where(group => group.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(group => group.Title, groupNew.Title)
            .SetProperty(group => group.UrlImage, groupNew.UrlImage)
            .SetProperty(group => group.Description, groupNew.Description)
            .SetProperty(group => group.FoundationDate, groupNew.FoundationDate), cancellationToken);
        }
        public async Task<List<Group>> GetGroupsByIdsAsync(List<int> groupIds)
        {
            return await spotifyDatabaseContext.Groups
                .Where(g => groupIds.Contains(g.Id))
                .ToListAsync();
        }
    }
}
