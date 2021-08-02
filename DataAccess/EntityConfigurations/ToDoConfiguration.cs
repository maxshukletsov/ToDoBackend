using System;
using Microsoft.EntityFrameworkCore;
using Domain.ToDo.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.Property(c => c.id).ValueGeneratedOnAdd();
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.DateCreated).HasDefaultValueSql("NOW()");
            builder.Property(c => c.DateEnding).IsRequired();
            builder.Property(c => c.End).HasDefaultValue(false);
        }
    }
}