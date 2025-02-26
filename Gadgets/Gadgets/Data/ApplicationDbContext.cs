using Microsoft.EntityFrameworkCore;
using HomeAutomationStore.Models;
using System;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System.Reflection.Emit;

namespace HomeAutomationStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision for Membership
            modelBuilder.Entity<Membership>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            // Configure decimal precision for Order
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            // Configure decimal precision for OrderItem
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.OriginalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.DiscountPercentage)
                .HasColumnType("decimal(18,2)");

            // Configure decimal precision for Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
   
        modelBuilder.Entity<Membership>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

        // Configure Review relationship
        modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        // First, seed the users
        modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Test User",
                    Email = "test@example.com",
                    PasswordHash = "test123",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new User
                {
                    Id = 2,
                    Name = "John Doe",
                    Email = "john@example.com",
                    PasswordHash = "test123",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            );

// Then seed the products
modelBuilder.Entity<Product>().HasData(
    new Product
    {
        Id = 1,
        Name = "Smart LED Bulb",
        Description = "Color changing smart LED bulb with WiFi control",
        Price = 29.99m,
        Category = "Lighting",
        ImageUrl = "https://images.unsplash.com/photo-1612523563676-709f47fab6ea?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 50,
        IsFeatured = true,
        PurchasePoints = 30,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 2,
        Name = "Security Camera",
        Description = "1080p HD wireless security camera with night vision",
        Price = 89.99m,
        Category = "Security",
        ImageUrl = "https://plus.unsplash.com/premium_photo-1675016457613-2291390d1bf6?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 30,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 3,
        Name = "Smart Thermostat",
        Description = "WiFi-enabled smart thermostat with energy saving features",
        Price = 149.99m,
        Category = "Climate",
        ImageUrl = "https://plus.unsplash.com/premium_photo-1729436833449-225649403fc0?q=80&w=1934&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 25,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 4,
        Name = "Smart Door Lock",
        Description = "Keyless entry smart door lock with fingerprint scanner",
        Price = 199.99m,
        Category = "Security",
        ImageUrl = "https://plus.unsplash.com/premium_photo-1729574858839-5a145c914bac?q=80&w=2088&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 20,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 5,
        Name = "LED Strip Lights",
        Description = "16ft RGB LED strip lights with app control",
        Price = 39.99m,
        Category = "Lighting",
        ImageUrl = "https://images.unsplash.com/photo-1659066019874-7a15628cea60?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 45,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 6,
        Name = "Smart TV Pro",
        Description = "65-inch 4K Smart TV with voice control",
        Price = 899.99m,
        Category = "Entertainment",
        ImageUrl = "https://images.unsplash.com/photo-1601944177325-f8867652837f?auto=format&fit=crop&w=800&q=80",
        StockQuantity = 15,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 7,
        Name = "Smart Doorbell Pro",
        Description = "Video doorbell with two-way audio",
        Price = 179.99m,
        Category = "Security",
        ImageUrl = "https://plus.unsplash.com/premium_photo-1729571572792-d211af573965?q=80&w=2088&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 30,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 8,
        Name = "Air Purifier Plus",
        Description = "Smart air purifier with PM2.5 sensor",
        Price = 299.99m,
        Category = "Climate",
        ImageUrl = "https://images.unsplash.com/photo-1634585605949-8f1e029af923?q=80&w=2128&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 25,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 9,
        Name = "Smart Speaker System",
        Description = "Wireless multi-room speaker system",
        Price = 399.99m,
        Category = "Entertainment",
        ImageUrl = "https://images.unsplash.com/photo-1589256469067-ea99122bbdc4?auto=format&fit=crop&w=800&q=80",
        StockQuantity = 20,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 10,
        Name = "Security System Pro",
        Description = "8-channel home security system",
        Price = 599.99m,
        Category = "Security",
        ImageUrl = "https://images.unsplash.com/photo-1558002038-1055907df827?auto=format&fit=crop&w=800&q=80",
        StockQuantity = 15,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 11,
        Name = "Smart Ceiling Fan",
        Description = "Smart ceiling fan with LED light",
        Price = 249.99m,
        Category = "Climate",
        ImageUrl = "https://images.unsplash.com/photo-1670996324046-f489f28de4e4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 30,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 12,
        Name = "Auto Blinds",
        Description = "Smart window blinds with scheduling",
        Price = 199.99m,
        Category = "Climate",
        ImageUrl = "https://plus.unsplash.com/premium_photo-1661922983577-f9c532b9f888?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 25,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 13,
        Name = "4K Smart Projector",
        Description = "4K smart projector with streaming",
        Price = 799.99m,
        Category = "Entertainment",
        ImageUrl = "https://images.unsplash.com/photo-1528395874238-34ebe249b3f2?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 10,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 14,
        Name = "Garage Control Pro",
        Description = "Smart garage door opener with camera",
        Price = 249.99m,
        Category = "Security",
        ImageUrl = "https://plus.unsplash.com/premium_photo-1661286705410-edb4c9bde72a?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 20,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 15,
        Name = "Smart Dehumidifier",
        Description = "App-controlled smart dehumidifier",
        Price = 199.99m,
        Category = "Climate",
        ImageUrl = "https://images.unsplash.com/photo-1558089687-f282ffcbc126?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 25,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 16,
        Name = "Smart Soundbar Pro",
        Description = "Voice-controlled smart soundbar with subwoofer",
        Price = 349.99m,
        Category = "Entertainment",
        ImageUrl = "https://images.unsplash.com/photo-1545454675-3531b543be5d?auto=format&fit=crop&w=800&q=80",
        StockQuantity = 20,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 17,
        Name = "Path Lights Set",
        Description = "Outdoor smart pathway lights with motion sensing",
        Price = 129.99m,
        Category = "Lighting",
        ImageUrl = "https://images.unsplash.com/photo-1505231509341-30534a9372ee?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 50,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 18,
        Name = "Leak Detector",
        Description = "Smart water leak detector with instant alerts",
        Price = 49.99m,
        Category = "Security",
        ImageUrl = "https://images.unsplash.com/photo-1526898943670-92bfa9f94c12?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 60,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 19,
        Name = "Portable Smart AC",
        Description = "Smart portable AC with voice control",
        Price = 449.99m,
        Category = "Climate",
        ImageUrl = "https://plus.unsplash.com/premium_photo-1679943423706-570c6462f9a4?q=80&w=2010&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 20,
        IsFeatured = true,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 20,
        Name = "Universal Remote Pro",
        Description = "Smart universal remote with touchscreen",
        Price = 79.99m,
        Category = "Entertainment",
        ImageUrl = "https://images.unsplash.com/photo-1584905066893-7d5c142ba4e1?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        StockQuantity = 40,
        IsFeatured = false,
        PurchasePoints = 10,
        IsMemberOnly = false
    },
    new Product
    {
        Id = 21,
        Name = "Premium Smart Hub",
        Description = "Advanced home automation hub with AI integration (Members Only)",
        Price = 299.99m,
        Category = "Control",
        ImageUrl = "https://images.unsplash.com/photo-1558002038-1055907df827?auto=format&fit=crop&w=800&q=80",
        StockQuantity = 15,
        IsMemberOnly = true,
        PurchasePoints = 300,
        IsFeatured = true
    },
    new Product
    {
        Id = 22,
        Name = "Elite Security Bundle",
        Description = "Complete home security system with professional monitoring (Members Only)",
        Price = 799.99m,
        Category = "Security",
        ImageUrl = "https://images.unsplash.com/photo-1557862921-37829c790f19?auto=format&fit=crop&w=800&q=80",
        StockQuantity = 10,
        IsMemberOnly = true,
        PurchasePoints = 800,
        IsFeatured = true
    },
    new Product
    {
        Id = 23,
        Name = "Smart Home Theater System",
        Description = "Premium entertainment system with Dolby Atmos (Members Only)",
        Price = 1499.99m,
        Category = "Entertainment",
        ImageUrl = "https://images.unsplash.com/photo-1593784991095-a205069470b6?auto=format&fit=crop&w=800&q=80",
        StockQuantity = 5,
        IsMemberOnly = true,
        PurchasePoints = 1500,
        IsFeatured = true
    }
);

// Finally, seed the reviews
modelBuilder.Entity<Review>().HasData(
    new Review
    {
        Id = 1,
        ProductId = 1,
        UserId = 1,
        Rating = 5,
        Comment = "Great smart bulb! The colors are vibrant and the app control works flawlessly.",
        CreatedAt = DateTime.UtcNow.AddDays(-5)
    },
    new Review
    {
        Id = 2,
        ProductId = 1,
        UserId = 2,
        Rating = 4,
        Comment = "Easy to set up and works well with my smart home system.",
        CreatedAt = DateTime.UtcNow.AddDays(-4)
    },
    new Review
    {
        Id = 3,
        ProductId = 2,
        UserId = 1,
        Rating = 4,
        Comment = "Good security camera with clear night vision. Setup was easy.",
        CreatedAt = DateTime.UtcNow.AddDays(-3)
    },
    new Review
    {
        Id = 4,
        ProductId = 2,
        UserId = 2,
        Rating = 5,
        Comment = "Excellent camera, great motion detection and clear video quality.",
        CreatedAt = DateTime.UtcNow.AddDays(-2)
    },
    new Review
    {
        Id = 5,
        ProductId = 3,
        UserId = 1,
        Rating = 5,
        Comment = "This smart thermostat has already saved me money on my energy bills!",
        CreatedAt = DateTime.UtcNow.AddDays(-2)
    },
    new Review
    {
        Id = 6,
        ProductId = 3,
        UserId = 2,
        Rating = 4,
        Comment = "Very intuitive interface and good temperature control.",
        CreatedAt = DateTime.UtcNow.AddDays(-1)
    }
);

// Add this to your existing seed data configuration
modelBuilder.Entity<Order>()
    .Property(o => o.OrderStatus)
    .HasDefaultValue("Pending");

modelBuilder.Entity<Product>()
    .Property(p => p.PurchasePoints)
    .HasDefaultValue(10); // Default points earned
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // No retry logic for connection issues
        }
    }
} 