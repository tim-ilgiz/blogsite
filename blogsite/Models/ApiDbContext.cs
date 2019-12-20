using blogsite.Maps;
using Microsoft.EntityFrameworkCore;


namespace blogsite.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Folder> Folders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item>().ToTable("Item");
            builder.Entity<Folder>().ToTable("Folder");
            base.OnModelCreating(builder);

            new ItemMap(builder.Entity<Item>());
            new FolderMap(builder.Entity<Folder>());
        }
    }
}