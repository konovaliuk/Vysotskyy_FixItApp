using Microsoft.EntityFrameworkCore;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.Infrastructure.Context;

public class AppDbContext : DbContext
{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ApplicationEntity> Applications { get; set; }

        public DbSet<FeedbackEntity> Feedbacks { get; set; }

        public DbSet<ItemEntity> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.Id);
            
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Id)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)");
            
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.RoleId)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)");

            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationEntity>()
                .HasKey(a => a.Id);
            
            modelBuilder.Entity<ApplicationEntity>()
                .Property(a => a.Id)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)");

            modelBuilder.Entity<ApplicationEntity>()
                .HasOne(a => a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationEntity>()
                .HasOne(a => a.Master)
                .WithOne()
                .HasForeignKey<ApplicationEntity>(a => a.MasterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FeedbackEntity>()
                .HasKey(f => f.Id);
            
            modelBuilder.Entity<FeedbackEntity>()
                .Property(f => f.Id)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)");
            
            modelBuilder.Entity<FeedbackEntity>()
                .HasOne(f => f.Application)
                .WithMany(a => a.Feedbacks)
                .HasForeignKey(f => f.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemEntity>()
                .HasKey(i => i.Id);
            
            modelBuilder.Entity<ItemEntity>()
                .Property(i => i.Id)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)");
            
            modelBuilder.Entity<ItemEntity>()
                .HasOne(i => i.Application)
                .WithMany(a => a.Items)
                .HasForeignKey(i => i.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<RoleEntity>()
                .HasKey(r => r.Id);
            
            modelBuilder.Entity<RoleEntity>()
                .Property(r => r.Id)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)");

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = Guid.NewGuid().ToString(), Name = "Customer" },
                new RoleEntity { Id = Guid.NewGuid().ToString(), Name = "Master" },
                new RoleEntity { Id = Guid.NewGuid().ToString(), Name = "Manager" });
            
        }
}