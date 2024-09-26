using Microsoft.EntityFrameworkCore;
using Spotify.Database.Data;
using Spotify.Database.Entities;
using Spotify.Database.Repositories.Interfaces;


namespace Spotify.Database.Repositories
{
    public class GroupRepository(SpotifyDatabaseContext spotifyDatabaseContext): IGroupRepository
    {
        public async Task AddAsync(Group group)
        {
            await spotifyDatabaseContext.AddAsync(group);
            await spotifyDatabaseContext.SaveChangesAsync();
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

        public async Task<Group> GetByIdAsync(int id) => 
            await spotifyDatabaseContext.Groups.SingleAsync(group => group.Id == id);

        public async Task RemoveAsync(int id)
        {
            await spotifyDatabaseContext.Groups.Where(group => group.Id == id).ExecuteDeleteAsync();
            await spotifyDatabaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Group groupNew)
        {
            await spotifyDatabaseContext.Groups.Where(group => group.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(group => group.Title, groupNew.Title)
            .SetProperty(group => group.UrlImage, groupNew.UrlImage)
            .SetProperty(group => group.Description, groupNew.Description)
            .SetProperty(group => group.FoundationDate, groupNew.FoundationDate));
        }

        public async Task<List<Group>> GetGroupsByIdsAsync(List<int> groupIds)
        {
            return await spotifyDatabaseContext.Groups
                .Where(g => groupIds.Contains(g.Id))
                .ToListAsync();
        }
    }

}
