using Microsoft.EntityFrameworkCore;
using Spotify.Domain.Entities;
using Spotify.Persistense.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Persistense
{
    public class SpotifyDatabaseContext(DbContextOptions<SpotifyDatabaseContext> options) : DbContext(options)
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GroupConfigiration());
        }
    }
}
