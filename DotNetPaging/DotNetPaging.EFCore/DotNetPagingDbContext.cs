using Microsoft.EntityFrameworkCore;

namespace DotNetPaging.EFCore
{
    public class DotNetPagingDbContext : DbContext
    {
        public DotNetPagingDbContext(DbContextOptions<DotNetPagingDbContext> options) : base(options)
        {
        }

        public DbSet<PressRelease> PressReleases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PressRelease>().HasKey(k => k.Id);
            modelBuilder.Entity<PressRelease>().HasIndex(i => i.ReleaseDate);
        }
    }
}
