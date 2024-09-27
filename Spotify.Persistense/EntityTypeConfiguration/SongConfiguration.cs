using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Persistense.EntityTypeConfiguration
{
    public class SongConfiguration: IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(song => song.Id);
            builder.HasIndex(song => song.Id).IsUnique();
            builder.Property(song => song.Title).HasMaxLength(100);
        }
    }
}
