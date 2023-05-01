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
                .Property(u => u.Name)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Surname)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Login)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Password)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

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
                .Property(a => a.Title)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            modelBuilder.Entity<ApplicationEntity>()
                .Property(a => a.Description)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            modelBuilder.Entity<ApplicationEntity>()
                .Property(a => a.Status)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            modelBuilder.Entity<ApplicationEntity>()
                .Property(a => a.Price)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<ApplicationEntity>()
                .HasOne(a => a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.ClientId);

            // modelBuilder.Entity<ApplicationEntity>()
            //         .HasOne(a => a.Master)
            //         .WithOne()
            //         .HasForeignKey<ApplicationEntity>(a => a.MasterId);

            modelBuilder.Entity<FeedbackEntity>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<FeedbackEntity>()
                .Property(f => f.Id)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)");
            
            modelBuilder.Entity<FeedbackEntity>()
                .Property(f => f.Context)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
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
                .Property(i => i.Name)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            modelBuilder.Entity<ItemEntity>()
                .Property(i => i.Problem)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
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
            
            modelBuilder.Entity<RoleEntity>()
                .Property(r => r.Name)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = Guid.NewGuid().ToString(), Name = "Customer" },
                new RoleEntity { Id = Guid.NewGuid().ToString(), Name = "Master" },
                new RoleEntity { Id = Guid.NewGuid().ToString(), Name = "Manager" });
            
        }
}