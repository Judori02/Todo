using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Data.Base;
using Todo.Web.Data.Configurations;
using Todo.Web.Data.Entities;

namespace Todo.Web.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User>, IBaseDbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ToDoItemConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TagConfiguration());

            base.OnModelCreating(builder);
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }
        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new())
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
