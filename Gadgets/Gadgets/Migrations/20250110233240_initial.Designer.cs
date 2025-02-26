﻿// <auto-generated />
using System;
using HomeAutomationStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gadgets.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250110233240_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeAutomationStore.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PointsToUse")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("UsePoints")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Pending");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PointsUsed")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("UsePoints")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMemberOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PurchasePoints")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10);

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Lighting",
                            Description = "Color changing smart LED bulb with WiFi control",
                            ImageUrl = "https://images.unsplash.com/photo-1612523563676-709f47fab6ea?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Smart LED Bulb",
                            Price = 29.99m,
                            PurchasePoints = 30,
                            StockQuantity = 50
                        },
                        new
                        {
                            Id = 2,
                            Category = "Security",
                            Description = "1080p HD wireless security camera with night vision",
                            ImageUrl = "https://plus.unsplash.com/premium_photo-1675016457613-2291390d1bf6?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Security Camera",
                            Price = 89.99m,
                            PurchasePoints = 10,
                            StockQuantity = 30
                        },
                        new
                        {
                            Id = 3,
                            Category = "Climate",
                            Description = "WiFi-enabled smart thermostat with energy saving features",
                            ImageUrl = "https://plus.unsplash.com/premium_photo-1729436833449-225649403fc0?q=80&w=1934&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Smart Thermostat",
                            Price = 149.99m,
                            PurchasePoints = 10,
                            StockQuantity = 25
                        },
                        new
                        {
                            Id = 4,
                            Category = "Security",
                            Description = "Keyless entry smart door lock with fingerprint scanner",
                            ImageUrl = "https://plus.unsplash.com/premium_photo-1729574858839-5a145c914bac?q=80&w=2088&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Smart Door Lock",
                            Price = 199.99m,
                            PurchasePoints = 10,
                            StockQuantity = 20
                        },
                        new
                        {
                            Id = 5,
                            Category = "Lighting",
                            Description = "16ft RGB LED strip lights with app control",
                            ImageUrl = "https://images.unsplash.com/photo-1659066019874-7a15628cea60?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "LED Strip Lights",
                            Price = 39.99m,
                            PurchasePoints = 10,
                            StockQuantity = 45
                        },
                        new
                        {
                            Id = 6,
                            Category = "Entertainment",
                            Description = "65-inch 4K Smart TV with voice control",
                            ImageUrl = "https://images.unsplash.com/photo-1601944177325-f8867652837f?auto=format&fit=crop&w=800&q=80",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Smart TV Pro",
                            Price = 899.99m,
                            PurchasePoints = 10,
                            StockQuantity = 15
                        },
                        new
                        {
                            Id = 7,
                            Category = "Security",
                            Description = "Video doorbell with two-way audio",
                            ImageUrl = "https://plus.unsplash.com/premium_photo-1729571572792-d211af573965?q=80&w=2088&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Smart Doorbell Pro",
                            Price = 179.99m,
                            PurchasePoints = 10,
                            StockQuantity = 30
                        },
                        new
                        {
                            Id = 8,
                            Category = "Climate",
                            Description = "Smart air purifier with PM2.5 sensor",
                            ImageUrl = "https://images.unsplash.com/photo-1634585605949-8f1e029af923?q=80&w=2128&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Air Purifier Plus",
                            Price = 299.99m,
                            PurchasePoints = 10,
                            StockQuantity = 25
                        },
                        new
                        {
                            Id = 9,
                            Category = "Entertainment",
                            Description = "Wireless multi-room speaker system",
                            ImageUrl = "https://images.unsplash.com/photo-1589256469067-ea99122bbdc4?auto=format&fit=crop&w=800&q=80",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Smart Speaker System",
                            Price = 399.99m,
                            PurchasePoints = 10,
                            StockQuantity = 20
                        },
                        new
                        {
                            Id = 10,
                            Category = "Security",
                            Description = "8-channel home security system",
                            ImageUrl = "https://images.unsplash.com/photo-1558002038-1055907df827?auto=format&fit=crop&w=800&q=80",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Security System Pro",
                            Price = 599.99m,
                            PurchasePoints = 10,
                            StockQuantity = 15
                        },
                        new
                        {
                            Id = 11,
                            Category = "Climate",
                            Description = "Smart ceiling fan with LED light",
                            ImageUrl = "https://images.unsplash.com/photo-1670996324046-f489f28de4e4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Smart Ceiling Fan",
                            Price = 249.99m,
                            PurchasePoints = 10,
                            StockQuantity = 30
                        },
                        new
                        {
                            Id = 12,
                            Category = "Climate",
                            Description = "Smart window blinds with scheduling",
                            ImageUrl = "https://plus.unsplash.com/premium_photo-1661922983577-f9c532b9f888?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Auto Blinds",
                            Price = 199.99m,
                            PurchasePoints = 10,
                            StockQuantity = 25
                        },
                        new
                        {
                            Id = 13,
                            Category = "Entertainment",
                            Description = "4K smart projector with streaming",
                            ImageUrl = "https://images.unsplash.com/photo-1528395874238-34ebe249b3f2?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "4K Smart Projector",
                            Price = 799.99m,
                            PurchasePoints = 10,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 14,
                            Category = "Security",
                            Description = "Smart garage door opener with camera",
                            ImageUrl = "https://plus.unsplash.com/premium_photo-1661286705410-edb4c9bde72a?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Garage Control Pro",
                            Price = 249.99m,
                            PurchasePoints = 10,
                            StockQuantity = 20
                        },
                        new
                        {
                            Id = 15,
                            Category = "Climate",
                            Description = "App-controlled smart dehumidifier",
                            ImageUrl = "https://images.unsplash.com/photo-1558089687-f282ffcbc126?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Smart Dehumidifier",
                            Price = 199.99m,
                            PurchasePoints = 10,
                            StockQuantity = 25
                        },
                        new
                        {
                            Id = 16,
                            Category = "Entertainment",
                            Description = "Voice-controlled smart soundbar with subwoofer",
                            ImageUrl = "https://images.unsplash.com/photo-1545454675-3531b543be5d?auto=format&fit=crop&w=800&q=80",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Smart Soundbar Pro",
                            Price = 349.99m,
                            PurchasePoints = 10,
                            StockQuantity = 20
                        },
                        new
                        {
                            Id = 17,
                            Category = "Lighting",
                            Description = "Outdoor smart pathway lights with motion sensing",
                            ImageUrl = "https://images.unsplash.com/photo-1505231509341-30534a9372ee?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Path Lights Set",
                            Price = 129.99m,
                            PurchasePoints = 10,
                            StockQuantity = 50
                        },
                        new
                        {
                            Id = 18,
                            Category = "Security",
                            Description = "Smart water leak detector with instant alerts",
                            ImageUrl = "https://images.unsplash.com/photo-1526898943670-92bfa9f94c12?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Leak Detector",
                            Price = 49.99m,
                            PurchasePoints = 10,
                            StockQuantity = 60
                        },
                        new
                        {
                            Id = 19,
                            Category = "Climate",
                            Description = "Smart portable AC with voice control",
                            ImageUrl = "https://plus.unsplash.com/premium_photo-1679943423706-570c6462f9a4?q=80&w=2010&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = true,
                            IsMemberOnly = false,
                            Name = "Portable Smart AC",
                            Price = 449.99m,
                            PurchasePoints = 10,
                            StockQuantity = 20
                        },
                        new
                        {
                            Id = 20,
                            Category = "Entertainment",
                            Description = "Smart universal remote with touchscreen",
                            ImageUrl = "https://images.unsplash.com/photo-1584905066893-7d5c142ba4e1?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsFeatured = false,
                            IsMemberOnly = false,
                            Name = "Universal Remote Pro",
                            Price = 79.99m,
                            PurchasePoints = 10,
                            StockQuantity = 40
                        },
                        new
                        {
                            Id = 21,
                            Category = "Control",
                            Description = "Advanced home automation hub with AI integration (Members Only)",
                            ImageUrl = "https://images.unsplash.com/photo-1558002038-1055907df827?auto=format&fit=crop&w=800&q=80",
                            IsFeatured = true,
                            IsMemberOnly = true,
                            Name = "Premium Smart Hub",
                            Price = 299.99m,
                            PurchasePoints = 300,
                            StockQuantity = 15
                        },
                        new
                        {
                            Id = 22,
                            Category = "Security",
                            Description = "Complete home security system with professional monitoring (Members Only)",
                            ImageUrl = "https://images.unsplash.com/photo-1557862921-37829c790f19?auto=format&fit=crop&w=800&q=80",
                            IsFeatured = true,
                            IsMemberOnly = true,
                            Name = "Elite Security Bundle",
                            Price = 799.99m,
                            PurchasePoints = 800,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 23,
                            Category = "Entertainment",
                            Description = "Premium entertainment system with Dolby Atmos (Members Only)",
                            ImageUrl = "https://images.unsplash.com/photo-1593784991095-a205069470b6?auto=format&fit=crop&w=800&q=80",
                            IsFeatured = true,
                            IsMemberOnly = true,
                            Name = "Smart Home Theater System",
                            Price = 1499.99m,
                            PurchasePoints = 1500,
                            StockQuantity = 5
                        });
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Great smart bulb! The colors are vibrant and the app control works flawlessly.",
                            CreatedAt = new DateTime(2025, 1, 5, 23, 32, 39, 781, DateTimeKind.Utc).AddTicks(8891),
                            ProductId = 1,
                            Rating = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Comment = "Easy to set up and works well with my smart home system.",
                            CreatedAt = new DateTime(2025, 1, 6, 23, 32, 39, 781, DateTimeKind.Utc).AddTicks(9135),
                            ProductId = 1,
                            Rating = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Comment = "Good security camera with clear night vision. Setup was easy.",
                            CreatedAt = new DateTime(2025, 1, 7, 23, 32, 39, 781, DateTimeKind.Utc).AddTicks(9140),
                            ProductId = 2,
                            Rating = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Comment = "Excellent camera, great motion detection and clear video quality.",
                            CreatedAt = new DateTime(2025, 1, 8, 23, 32, 39, 781, DateTimeKind.Utc).AddTicks(9142),
                            ProductId = 2,
                            Rating = 5,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Comment = "This smart thermostat has already saved me money on my energy bills!",
                            CreatedAt = new DateTime(2025, 1, 8, 23, 32, 39, 781, DateTimeKind.Utc).AddTicks(9144),
                            ProductId = 3,
                            Rating = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            Comment = "Very intuitive interface and good temperature control.",
                            CreatedAt = new DateTime(2025, 1, 9, 23, 32, 39, 781, DateTimeKind.Utc).AddTicks(9146),
                            ProductId = 3,
                            Rating = 4,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("HomeAutomationStore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 10, 23, 32, 39, 780, DateTimeKind.Utc).AddTicks(9872),
                            Email = "test@example.com",
                            IsActive = true,
                            Name = "Test User",
                            PasswordHash = "test123",
                            Points = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 10, 23, 32, 39, 781, DateTimeKind.Utc).AddTicks(205),
                            Email = "john@example.com",
                            IsActive = true,
                            Name = "John Doe",
                            PasswordHash = "test123",
                            Points = 0
                        });
                });

            modelBuilder.Entity("HomeAutomationStore.Models.CartItem", b =>
                {
                    b.HasOne("HomeAutomationStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeAutomationStore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Membership", b =>
                {
                    b.HasOne("HomeAutomationStore.Models.User", "User")
                        .WithOne("Membership")
                        .HasForeignKey("HomeAutomationStore.Models.Membership", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Order", b =>
                {
                    b.HasOne("HomeAutomationStore.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.OrderItem", b =>
                {
                    b.HasOne("HomeAutomationStore.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeAutomationStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Review", b =>
                {
                    b.HasOne("HomeAutomationStore.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeAutomationStore.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.Product", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("HomeAutomationStore.Models.User", b =>
                {
                    b.Navigation("Membership")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
