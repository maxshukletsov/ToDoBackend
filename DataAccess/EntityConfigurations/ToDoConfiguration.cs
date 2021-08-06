using Microsoft.EntityFrameworkCore;
using Domain.ToDo.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.Property(td => td.Id).ValueGeneratedOnAdd();
            builder.Property(td => td.Title).IsRequired();
            builder.Property(td => td.DateCreated).HasDefaultValueSql("NOW()");
            builder.Property(td => td.DateEnding).IsRequired();
            builder.Property(td => td.End).HasDefaultValue(false);
            builder
                .HasOne(td => td.User)
                .WithMany(td => td.ToDo);
        }
    }
}