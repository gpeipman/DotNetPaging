using System.Data.Entity;

namespace DotNetPaging.EF
{
    public class DotNetPagingDbContext : DbContext
    { 
        public DotNetPagingDbContext() : base("name=DefaultConnection")
        {
        }
    
        public DbSet<PressRelease> PressReleases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PressRelease>().HasKey(k => k.Id);
            modelBuilder.Entity<PressRelease>().HasIndex(i => i.ReleaseDate);
        }
    }
}
