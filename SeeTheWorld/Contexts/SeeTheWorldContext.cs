using Microsoft.EntityFrameworkCore;

using SeeTheWorld.Entities;

namespace SeeTheWorld.Contexts
{
    public class SeeTheWorldContext : DbContext
    {
        public SeeTheWorldContext(DbContextOptions<SeeTheWorldContext> options) : base(options)
        {
            // CTOR
        }

        public DbSet<PictureEntity> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PictureEntity>()
                .HasKey(it => it.Id);
        }
    }
}
