using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class ProductContext : DbContext
{
    public ProductContext()
    {
    }

    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryEntity> Categories { get; set; }

    public virtual DbSet<ManufactureEntity> Manufactures { get; set; }

    public virtual DbSet<PriceEntity> Prices { get; set; }

    public virtual DbSet<ProductEntity> Products { get; set; }

    public virtual DbSet<ProductPictureEntity> ProductPictures { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC074A627D97");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ManufactureEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manufact__3214EC07EC70FA84");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PriceEntity>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Prices__B40CC6CD58C46E93");

            entity.HasOne(d => d.Product).WithOne(p => p.Price)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prices__ProductI__5165187F");
        });

        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.HasKey(e => e.ArticleNumber).HasName("PK__Products__3C991143248F78A8");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Catego__4D94879B");

            entity.HasOne(d => d.Manufacture).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Manufa__4CA06362");

            entity.HasOne(d => d.ProductPicture).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Produc__4E88ABD4");
        });

        modelBuilder.Entity<ProductPictureEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductP__3214EC07061C4B58");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
