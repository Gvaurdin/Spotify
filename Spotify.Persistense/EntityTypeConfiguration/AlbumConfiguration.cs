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
    public class AlbumConfiguration: IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(album => album.Id);
            builder.HasIndex(album => album.Id).IsUnique();
            builder.Property(album => album.Title).HasMaxLength(100);
        }
    }
}
