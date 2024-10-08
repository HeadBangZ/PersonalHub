﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Domain.Common.Entities;
using ProjectHub.Domain.Common.ValueObjects;

namespace ProjectHub.Infrastructure.Data.Configurations
{
    internal class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasConversion(
                tagId => tagId.Id,
                value => new TagId(value));

            builder.Property(t => t.Name)
                .HasMaxLength(100);

            builder.Property(t => t.Color)
                .HasMaxLength(7);
        }
    }
}
