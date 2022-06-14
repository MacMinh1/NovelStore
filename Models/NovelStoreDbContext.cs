using Microsoft.EntityFrameworkCore;
namespace NovelStore.Models
{
    public class NovelStoreDbContext : DbContext
    {
        public NovelStoreDbContext(DbContextOptions<NovelStoreDbContext>options): base(options) { }
        public DbSet<Novel> Novels { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}