﻿// <auto-generated />
using System;
using GuitarStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GuitarStore.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GuitarStore.Models.AddToShoppingCart", b =>
                {
                    b.Property<int>("AddToShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AddToShoppingCartId"));

                    b.Property<int>("GuitarId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdd")
                        .HasColumnType("boolean");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("AddToShoppingCartId");

                    b.HasIndex("GuitarId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("AddToShoppingCarts");
                });

            modelBuilder.Entity("GuitarStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GuitarStore.Models.Guitar", b =>
                {
                    b.Property<int>("GuitarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GuitarId"));

                    b.Property<int>("AddToShoppingCartId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("GuitarCompany")
                        .HasColumnType("text");

                    b.Property<string>("GuitarDescription")
                        .HasColumnType("text");

                    b.Property<string>("GuitarModel")
                        .HasColumnType("text");

                    b.Property<string>("GuitarPickups")
                        .HasColumnType("text");

                    b.Property<string>("Guitarwood")
                        .HasColumnType("text");

                    b.Property<int>("LikeId")
                        .HasColumnType("integer");

                    b.Property<string>("ListPhotoUrl1")
                        .HasColumnType("text");

                    b.Property<string>("ListPhotoUrl2")
                        .HasColumnType("text");

                    b.Property<string>("ListPhotoUrl3")
                        .HasColumnType("text");

                    b.Property<string>("ListPhotoUrl4")
                        .HasColumnType("text");

                    b.Property<string>("ListPhotoUrl5")
                        .HasColumnType("text");

                    b.Property<string>("ListPhotoUrl6")
                        .HasColumnType("text");

                    b.Property<int?>("NumberOfStrings")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("StockId")
                        .HasColumnType("integer");

                    b.Property<string>("StringMaterials")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("GuitarId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("StockId");

                    b.HasIndex("UserId");

                    b.ToTable("Guitars");
                });

            modelBuilder.Entity("GuitarStore.Models.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LikeId"));

                    b.Property<int>("GuitarId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsLike")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LikeId");

                    b.HasIndex("GuitarId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("GuitarStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int>("GuitarId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsOrder")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GuitarStore.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StockId"));

                    b.Property<string>("StockAddress")
                        .HasColumnType("text");

                    b.Property<string>("StockName")
                        .HasColumnType("text");

                    b.HasKey("StockId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("GuitarStore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("UserConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GuitarStore.Models.AddToShoppingCart", b =>
                {
                    b.HasOne("GuitarStore.Models.Guitar", "Guitar")
                        .WithOne("AddToShoppingCart")
                        .HasForeignKey("GuitarStore.Models.AddToShoppingCart", "GuitarId")
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.User", "User")
                        .WithMany("addToShoppingCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guitar");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuitarStore.Models.Guitar", b =>
                {
                    b.HasOne("GuitarStore.Models.Category", "Category")
                        .WithMany("Guitars")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.Order", "Order")
                        .WithOne("Guitar")
                        .HasForeignKey("GuitarStore.Models.Guitar", "OrderId")
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.Stock", "Stock")
                        .WithMany("Guitars")
                        .HasForeignKey("StockId")
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Order");

                    b.Navigation("Stock");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuitarStore.Models.Like", b =>
                {
                    b.HasOne("GuitarStore.Models.Guitar", "Guitar")
                        .WithOne("Like")
                        .HasForeignKey("GuitarStore.Models.Like", "GuitarId")
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guitar");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuitarStore.Models.Order", b =>
                {
                    b.HasOne("GuitarStore.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuitarStore.Models.Category", b =>
                {
                    b.Navigation("Guitars");
                });

            modelBuilder.Entity("GuitarStore.Models.Guitar", b =>
                {
                    b.Navigation("AddToShoppingCart");

                    b.Navigation("Like");
                });

            modelBuilder.Entity("GuitarStore.Models.Order", b =>
                {
                    b.Navigation("Guitar");
                });

            modelBuilder.Entity("GuitarStore.Models.Stock", b =>
                {
                    b.Navigation("Guitars");
                });

            modelBuilder.Entity("GuitarStore.Models.User", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Orders");

                    b.Navigation("addToShoppingCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
