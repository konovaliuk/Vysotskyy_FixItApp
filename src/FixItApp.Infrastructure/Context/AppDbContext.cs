using Microsoft.EntityFrameworkCore;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.Infrastructure.Context;

public class AppDbContext : DbContext
{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /*
        public AppDbContext()
        {

        }*/

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ApplicationEntity> Applications { get; set; }

        public DbSet<FeedbackEntity> Feedbacks { get; set; }

        public DbSet<ItemEntity> Items { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=FixItApp;User=root;Password=password;",
                            new MySqlServerVersion(new Version(8, 0, 11)));
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

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
                .HasOne(f => f.Application)
                .WithMany(a => a.Feedbacks)
                .HasForeignKey(f => f.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemEntity>()
                .HasOne(i => i.Application)
                .WithMany(a => a.Items)
                .HasForeignKey(i => i.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
}