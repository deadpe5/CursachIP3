using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Context
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        { }

        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderMember> OrderMembers { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderWare> OrderWares { get; set; }
        public DbSet<RAM> RAM { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ware> Ware { get; set; }
        public DbSet<WareStatus> WareStatus { get; set; }
        public DbSet<WareType> WareTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new WareStatusConfiguration());
            modelBuilder.ApplyConfiguration(new WareTypeConfiguration());
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

    public class WareStatusConfiguration : IEntityTypeConfiguration<WareStatus>
    {
        public void Configure(EntityTypeBuilder<WareStatus> builder)
        {
            builder.HasData(
                new WareStatus() { Id = 1, StatusName = "In store" },
                new WareStatus() { Id = 2, StatusName = "In stock" },
                new WareStatus() { Id = 3, StatusName = "Not avaible" }
                );
        }
    }

    public class WareTypeConfiguration : IEntityTypeConfiguration<WareType>
    {
        public void Configure(EntityTypeBuilder<WareType> builder)
        {
            builder.HasData(
                new WareType() { Id = 1, TypeName = "CPU" },
                new WareType() { Id = 2, TypeName = "GPU" },
                new WareType() { Id = 3, TypeName = "RAM" });
        }
    }

    // DEVELOPMENT ONLY
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User() { Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    Email = "admin@mail.ua",
                    Phone = "0951234567",
                    Password = "admin",
                    RoleId = 1,
                    GenderId = 3}
                );
        }
    }
}
