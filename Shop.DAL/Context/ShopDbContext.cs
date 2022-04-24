using Microsoft.EntityFrameworkCore;
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
    }
}
