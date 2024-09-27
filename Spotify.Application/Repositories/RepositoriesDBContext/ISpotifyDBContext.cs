using Microsoft.EntityFrameworkCore;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Repositories.RepositoriesDBContext
{
    public interface ISpotifyDBContext
    {
        DbSet<Group> Groups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
