﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop.DAL.Context;

#nullable disable

namespace Shop.DAL.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shop.DAL.Entities.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoreCount")
                        .HasColumnType("integer");

                    b.Property<int>("Speed")
                        .HasColumnType("integer");

                    b.Property<int>("TDP")
                        .HasColumnType("integer");

                    b.Property<int>("WareId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WareId");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GenderName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Shop.DAL.Entities.GPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Speed")
                        .HasColumnType("integer");

                    b.Property<int>("TDP")
                        .HasColumnType("integer");

                    b.Property<int>("VRAMSize")
                        .HasColumnType("integer");

                    b.Property<int>("WareId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WareId");

                    b.ToTable("GPUs");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shop.DAL.Entities.OrderMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderMembers");
                });

            modelBuilder.Entity("Shop.DAL.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("OrderStatusName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Shop.DAL.Entities.OrderWare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("WareId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("WareId");

                    b.ToTable("OrderWares");
                });

            modelBuilder.Entity("Shop.DAL.Entities.RAM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<int>("Speed")
                        .HasColumnType("integer");

                    b.Property<int>("WareId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WareId");

                    b.ToTable("RAM");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("PostalCode")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Shop.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("GenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Ware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Manufactured")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.Property<int>("WareStatudId")
                        .HasColumnType("integer");

                    b.Property<int?>("WareStatusId")
                        .HasColumnType("integer");

                    b.Property<int?>("WareTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WareStatusId");

                    b.HasIndex("WareTypeId");

                    b.ToTable("Ware");
                });

            modelBuilder.Entity("Shop.DAL.Entities.WareStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WareStatus");
                });

            modelBuilder.Entity("Shop.DAL.Entities.WareType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WareTypes");
                });

            modelBuilder.Entity("Shop.DAL.Entities.CPU", b =>
                {
                    b.HasOne("Shop.DAL.Entities.Ware", "Ware")
                        .WithMany("CPUs")
                        .HasForeignKey("WareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ware");
                });

            modelBuilder.Entity("Shop.DAL.Entities.GPU", b =>
                {
                    b.HasOne("Shop.DAL.Entities.Ware", "Ware")
                        .WithMany("GPUs")
                        .HasForeignKey("WareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ware");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Order", b =>
                {
                    b.HasOne("Shop.DAL.Entities.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("Shop.DAL.Entities.OrderMember", b =>
                {
                    b.HasOne("Shop.DAL.Entities.Order", "Order")
                        .WithMany("OrderMembers")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.DAL.Entities.User", "User")
                        .WithMany("OrderMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.DAL.Entities.OrderWare", b =>
                {
                    b.HasOne("Shop.DAL.Entities.Order", "Order")
                        .WithMany("OrderWares")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.DAL.Entities.Ware", "Ware")
                        .WithMany("OrderWares")
                        .HasForeignKey("WareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Ware");
                });

            modelBuilder.Entity("Shop.DAL.Entities.RAM", b =>
                {
                    b.HasOne("Shop.DAL.Entities.Ware", "Ware")
                        .WithMany("RAM")
                        .HasForeignKey("WareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ware");
                });

            modelBuilder.Entity("Shop.DAL.Entities.User", b =>
                {
                    b.HasOne("Shop.DAL.Entities.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Ware", b =>
                {
                    b.HasOne("Shop.DAL.Entities.Supplier", "Supplier")
                        .WithMany("Wares")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.DAL.Entities.WareStatus", "WareStatus")
                        .WithMany("Wares")
                        .HasForeignKey("WareStatusId");

                    b.HasOne("Shop.DAL.Entities.WareType", "WareType")
                        .WithMany("Wares")
                        .HasForeignKey("WareTypeId");

                    b.Navigation("Supplier");

                    b.Navigation("WareStatus");

                    b.Navigation("WareType");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderMembers");

                    b.Navigation("OrderWares");
                });

            modelBuilder.Entity("Shop.DAL.Entities.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Supplier", b =>
                {
                    b.Navigation("Wares");
                });

            modelBuilder.Entity("Shop.DAL.Entities.User", b =>
                {
                    b.Navigation("OrderMembers");
                });

            modelBuilder.Entity("Shop.DAL.Entities.Ware", b =>
                {
                    b.Navigation("CPUs");

                    b.Navigation("GPUs");

                    b.Navigation("OrderWares");

                    b.Navigation("RAM");
                });

            modelBuilder.Entity("Shop.DAL.Entities.WareStatus", b =>
                {
                    b.Navigation("Wares");
                });

            modelBuilder.Entity("Shop.DAL.Entities.WareType", b =>
                {
                    b.Navigation("Wares");
                });
#pragma warning restore 612, 618
        }
    }
}
