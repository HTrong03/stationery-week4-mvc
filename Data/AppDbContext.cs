using Microsoft.EntityFrameworkCore;
using StationeryWeek3.Mvc.Models;

namespace StationeryWeek3.Mvc.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Brand> Brands => Set<Brand>();

    public DbSet<Stationery> Stationeries => Set<Stationery>();

    public DbSet<StockIssue> StockIssues => Set<StockIssue>();

    public DbSet<StockIssueItem> StockIssueItems => Set<StockIssueItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Category
        modelBuilder.Entity<Category>()
            .Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        // Brand
        modelBuilder.Entity<Brand>()
            .Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        // Stationery
        modelBuilder.Entity<Stationery>()
            .Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        modelBuilder.Entity<Stationery>()
            .Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Stationery>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);

        // Relationship: Category - Stationery
        modelBuilder.Entity<Stationery>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Stationeries)
            .HasForeignKey(x => x.CategoryId);

        // Relationship: Brand - Stationery
        modelBuilder.Entity<Stationery>()
            .HasOne(x => x.Brand)
            .WithMany(x => x.Stationeries)
            .HasForeignKey(x => x.BrandId);

        // =========================
        // Seed Categories
        // =========================
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Bút"
            },
            new Category
            {
                Id = 2,
                Name = "Vở"
            },
            new Category
            {
                Id = 3,
                Name = "Dụng cụ"
            }
        );

        // =========================
        // Seed Brands
        // =========================
        modelBuilder.Entity<Brand>().HasData(
            new Brand
            {
                Id = 1,
                Name = "Thiên Long"
            },
            new Brand
            {
                Id = 2,
                Name = "Hồng Hà"
            },
            new Brand
            {
                Id = 3,
                Name = "FlexOffice"
            }
        );

        // =========================
        // Seed Stationeries
        // =========================
        modelBuilder.Entity<Stationery>().HasData(
            new Stationery
            {
                Id = 1,
                Code = "ST001",
                SupplierCode = "SUP001",
                Name = "Bút bi Thiên Long",
                Price = 5000,
                Quantity = 50,
                MinStock = 10,
                LastUpdatedAt = new DateTime(2026, 1, 1),

                CategoryId = 1,
                BrandId = 1
            },

            new Stationery
            {
                Id = 2,
                Code = "ST002",
                SupplierCode = "SUP002",
                Name = "Vở 200 trang",
                Price = 18000,
                Quantity = 8,
                MinStock = 10,
                LastUpdatedAt = new DateTime(2026, 1, 1),

                CategoryId = 2,
                BrandId = 2
            },

            new Stationery
            {
                Id = 3,
                Code = "ST003",
                SupplierCode = "SUP003",
                Name = "Thước kẻ 30cm",
                Price = 12000,
                Quantity = 40,
                MinStock = 10,
                LastUpdatedAt = new DateTime(2026, 1, 1),

                CategoryId = 3,
                BrandId = 3
            }
        );

        modelBuilder.Entity<Stationery>()
            .Property(x => x.SupplierCode)
            .HasMaxLength(50)
            .IsRequired();
    }
}