using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Context
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        { 

        }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsStatus> GoodsStatus { get; set; }
        public DbSet<GoodsType> GoodsTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsStatusConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                    new Role() { Id = 1, RoleName = "Administrator" },
                    new Role() { Id = 2, RoleName = "Moderator" },
                    new Role() { Id = 3, RoleName = "Client"} 
                    );
        }
    }

    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(
                new Gender() { Id = 1, GenderName = "Male" },
                new Gender() { Id = 2, GenderName = "Female" },
                new Gender() { Id = 3, GenderName = "Unknown" }
                );
        }
    }

    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasData(
                new OrderStatus() { Id = 1, OrderStatusName = "In Progress" },
                new OrderStatus() { Id = 2, OrderStatusName = "Finished" },
                new OrderStatus() { Id = 3, OrderStatusName = "Canceled" }
                );
        }
    }

    public class GoodsStatusConfiguration : IEntityTypeConfiguration<GoodsStatus>
    {
        public void Configure(EntityTypeBuilder<GoodsStatus> builder)
        {
            builder.HasData(
                new GoodsStatus() { Id = 1, StatusName = "In store" },
                new GoodsStatus() { Id = 2, StatusName = "In stock" },
                new GoodsStatus() { Id = 3, StatusName = "Not available" }
                );
        }
    }

    public class GoodsTypeConfiguration : IEntityTypeConfiguration<GoodsType>
    {
        public void Configure(EntityTypeBuilder<GoodsType> builder)
        {
            builder.HasData(
                new GoodsType() { Id = 1, TypeName = "Laptop" },
                new GoodsType() { Id = 2, TypeName = "Desktop" },
                new GoodsType() { Id = 3, TypeName = "Tablet" });
        }
    }

    // DEVELOPMENT ONLY
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            CreatePasswordHash("qwerty", out byte[] passwordHash, out byte[] passwordSalt);

            builder.HasData(
                new User() { Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    Email = "admin@mail.ua",
                    Phone = "0951234567",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    RoleId = 1,
                    GenderId = 3}
                );

            builder.HasData(
               new User()
               {
                   Id = 2,
                   Name = "Moderator",
                   Surname = "Moderator",
                   Email = "moderator@mail.ua",
                   Phone = "0501234567",
                   PasswordHash = passwordHash,
                   PasswordSalt = passwordSalt,
                   RoleId = 2,
                   GenderId = 3
               }
               );

            builder.HasData(
               new User()
               {
                   Id = 3,
                   Name = "Client",
                   Surname = "Client",
                   Email = "client@mail.ua",
                   Phone = "0671234567",
                   PasswordHash = passwordHash,
                   PasswordSalt = passwordSalt,
                   RoleId = 3,
                   GenderId = 3
               }
               );
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
