using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Web.Data.Entities;

namespace Todo.Web.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(80).IsRequired();
            builder.Property(e => e.Surname).HasMaxLength(80).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
