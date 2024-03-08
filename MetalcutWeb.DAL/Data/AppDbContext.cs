using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MetalcutWeb.DAL.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.RequestedUser)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.AcceptedUser)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }


    }
}
