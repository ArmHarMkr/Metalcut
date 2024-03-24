using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<ChatEntity> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

/*            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.RequestedUser)
                .WithMany()
                .HasForeignKey(d => d.RequestedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.AcceptedUser)
                .WithMany()
                .HasForeignKey(d => d.AcceptedUserId)
                .OnDelete(DeleteBehavior.Restrict);*/
            
/*            modelBuilder.Entity<ChatEntity>()
                .HasOne(u => u.UserOne)
                .WithMany()
                .HasForeignKey(u => u.UserOneId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ChatEntity>()
                .HasOne(u => u.UserTwo)
                .WithMany()
                .HasForeignKey(u => u.UserTwoId)
                .OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}

