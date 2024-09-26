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
    public class GroupConfigiration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(group => group.Id);
            builder.HasIndex(group => group.Id).IsUnique();
            builder.Property(group => group.Title).HasMaxLength(100);
        }
    }
}
