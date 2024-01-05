﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CornerStore.Migrations
{
    [DbContext(typeof(CornerStoreDbContext))]
    [Migration("20240105171629_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CornerStore.Models.Cashier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cashiers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Donna",
                            LastName = "Franklin"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "John",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Emily",
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Michael",
                            LastName = "Williams"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Sophia",
                            LastName = "Davis"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Daniel",
                            LastName = "Miller"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Olivia",
                            LastName = "Jones"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Ethan",
                            LastName = "Moore"
                        });
                });

            modelBuilder.Entity("CornerStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Printed Material"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Beverages"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Snacks"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Personal Care"
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Household Items"
                        });
                });

            modelBuilder.Entity("CornerStore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CashierId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PaidOnDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CashierId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CashierId = 1,
                            PaidOnDate = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CashierId = 2,
                            PaidOnDate = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CashierId = 3,
                            PaidOnDate = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CashierId = 4,
                            PaidOnDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CashierId = 5,
                            PaidOnDate = new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CashierId = 6,
                            PaidOnDate = new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CashierId = 7,
                            PaidOnDate = new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            CashierId = 8,
                            PaidOnDate = new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            CashierId = 1
                        },
                        new
                        {
                            Id = 10,
                            CashierId = 2
                        });
                });

            modelBuilder.Entity("CornerStore.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            ProductId = 8,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            ProductId = 3,
                            Quantity = 6
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 2,
                            ProductId = 10,
                            Quantity = 4
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 2,
                            ProductId = 4,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            OrderId = 3,
                            ProductId = 19,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 7,
                            OrderId = 4,
                            ProductId = 18,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 8,
                            OrderId = 5,
                            ProductId = 23,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 9,
                            OrderId = 6,
                            ProductId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 10,
                            OrderId = 7,
                            ProductId = 13,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 11,
                            OrderId = 7,
                            ProductId = 24,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 12,
                            OrderId = 8,
                            ProductId = 20,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 13,
                            OrderId = 9,
                            ProductId = 16,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 14,
                            OrderId = 9,
                            ProductId = 14,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 15,
                            OrderId = 10,
                            ProductId = 7,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 16,
                            OrderId = 10,
                            ProductId = 25,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 17,
                            OrderId = 10,
                            ProductId = 12,
                            Quantity = 20
                        });
                });

            modelBuilder.Entity("CornerStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Publisher X",
                            CategoryId = 1,
                            Price = 4.99m,
                            ProductName = "Magazine A"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Daily News",
                            CategoryId = 1,
                            Price = 1.99m,
                            ProductName = "Newspaper B"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Coca-Cola",
                            CategoryId = 2,
                            Price = 0.99m,
                            ProductName = "Diet Coke"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "SnackCo",
                            CategoryId = 3,
                            Price = 2.49m,
                            ProductName = "Potato Chips"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "CleanSmile",
                            CategoryId = 4,
                            Price = 3.99m,
                            ProductName = "Toothpaste"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "SoftTouch",
                            CategoryId = 5,
                            Price = 5.99m,
                            ProductName = "Paper Towels"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "HealthGuard",
                            CategoryId = 4,
                            Price = 8.99m,
                            ProductName = "Multivitamins"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "PowerCell",
                            CategoryId = 5,
                            Price = 6.49m,
                            ProductName = "AA Batteries"
                        },
                        new
                        {
                            Id = 9,
                            Brand = "WriteRight",
                            CategoryId = 5,
                            Price = 1.79m,
                            ProductName = "Notepad"
                        },
                        new
                        {
                            Id = 10,
                            Brand = "SweetTreat",
                            CategoryId = 3,
                            Price = 1.49m,
                            ProductName = "Chocolate Bar"
                        },
                        new
                        {
                            Id = 11,
                            Brand = "SilkyLocks",
                            CategoryId = 4,
                            Price = 4.49m,
                            ProductName = "Shampoo"
                        },
                        new
                        {
                            Id = 12,
                            Brand = "CleanUp",
                            CategoryId = 5,
                            Price = 7.99m,
                            ProductName = "Trash Bags"
                        },
                        new
                        {
                            Id = 13,
                            Brand = "GermGuard",
                            CategoryId = 4,
                            Price = 2.99m,
                            ProductName = "Hand Sanitizer"
                        },
                        new
                        {
                            Id = 14,
                            Brand = "BrightBeam",
                            CategoryId = 5,
                            Price = 9.99m,
                            ProductName = "Flashlight"
                        },
                        new
                        {
                            Id = 15,
                            Brand = "PowerUp",
                            CategoryId = 5,
                            Price = 19.99m,
                            ProductName = "Laptop Charger"
                        },
                        new
                        {
                            Id = 16,
                            Brand = "HealthyBite",
                            CategoryId = 3,
                            Price = 3.29m,
                            ProductName = "Granola Bars"
                        },
                        new
                        {
                            Id = 17,
                            Brand = "SparkleClean",
                            CategoryId = 5,
                            Price = 2.99m,
                            ProductName = "Dish Soap"
                        },
                        new
                        {
                            Id = 18,
                            Brand = "ReliefRx",
                            CategoryId = 4,
                            Price = 4.79m,
                            ProductName = "Pain Reliever"
                        },
                        new
                        {
                            Id = 19,
                            Brand = "SoundWave",
                            CategoryId = 5,
                            Price = 14.99m,
                            ProductName = "Earbuds"
                        },
                        new
                        {
                            Id = 20,
                            Brand = "PrintMaster",
                            CategoryId = 5,
                            Price = 6.99m,
                            ProductName = "Printer Paper"
                        },
                        new
                        {
                            Id = 21,
                            Brand = "FreshBreath",
                            CategoryId = 4,
                            Price = 3.49m,
                            ProductName = "Mouthwash"
                        },
                        new
                        {
                            Id = 22,
                            Brand = "NoteMaster",
                            CategoryId = 5,
                            Price = 2.49m,
                            ProductName = "Notebook"
                        },
                        new
                        {
                            Id = 23,
                            Brand = "BoostFuel",
                            CategoryId = 2,
                            Price = 2.99m,
                            ProductName = "Energy Drink"
                        },
                        new
                        {
                            Id = 24,
                            Brand = "SoftGlow",
                            CategoryId = 4,
                            Price = 4.29m,
                            ProductName = "Hand Lotion"
                        },
                        new
                        {
                            Id = 25,
                            Brand = "DataSaver",
                            CategoryId = 5,
                            Price = 8.49m,
                            ProductName = "USB Flash Drive"
                        });
                });

            modelBuilder.Entity("CornerStore.Models.Order", b =>
                {
                    b.HasOne("CornerStore.Models.Cashier", "Cashier")
                        .WithMany("Orders")
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cashier");
                });

            modelBuilder.Entity("CornerStore.Models.OrderProduct", b =>
                {
                    b.HasOne("CornerStore.Models.Order", null)
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CornerStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CornerStore.Models.Product", b =>
                {
                    b.HasOne("CornerStore.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CornerStore.Models.Cashier", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CornerStore.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CornerStore.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
