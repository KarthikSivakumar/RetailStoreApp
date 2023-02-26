using System;
using System.Collections.Generic;
using RetailStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace RetailStoreWeb.Data;

public partial class RetailStoreDBContext : DbContext
{
    private readonly IConfiguration _config;
    public RetailStoreDBContext()
    {
        
    }
    public RetailStoreDBContext(IConfiguration config)
    {
        _config = config;
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsStaging> ProductsStagings { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer(_config.GetConnectionString("ProductsDB"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Sku).HasName("PK__Products__CA1ECF0C653BF2BB");

            entity.Property(e => e.Sku)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SKU");
            entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StoreId).HasColumnName("StoreID");

            entity.HasOne(d => d.Store).WithMany(p => p.Products)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK_Storeid");
        });

        modelBuilder.Entity<ProductsStaging>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Products_Staging");

            entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sku)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SKU");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Stores__3B82F0E1406EF1C2");

            entity.Property(e => e.StoreId)
                .ValueGeneratedNever()
                .HasColumnName("StoreID");
            entity.Property(e => e.StoreName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
