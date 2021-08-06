using Microsoft.EntityFrameworkCore;
using Domain.User.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.UserConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.HasMany(u => u.ToDo)
                .WithOne(u => u.User);
        }
    }
}