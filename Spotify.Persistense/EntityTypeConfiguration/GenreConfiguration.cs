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
    public class GenreConfiguration: IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(genre => genre.Id);
            builder.HasIndex(genre => genre.Id).IsUnique();
            builder.Property(genre => genre.Title).HasMaxLength(100);
        }
    }
}
