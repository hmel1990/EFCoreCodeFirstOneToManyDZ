using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class MyNewDbContext : DbContext
{
    public MyNewDbContext()
    {
    }

    public MyNewDbContext(DbContextOptions<MyNewDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MarketPlace;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.HasIndex(e => e.IdProduct, "IX_Order_id_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_Order_Product");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.ToTable("Producer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.IdCategory, "IX_Product_id_category");

            entity.HasIndex(e => e.IdProducer, "IX_Product_id_producer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdProducer).HasColumnName("id_producer");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductPicture).HasColumnName("productPicture");
            entity.Property(e => e.ProductPicturePath).HasColumnName("productPicturePath");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.IdProducerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProducer)
                .HasConstraintName("FK_Product_Producer");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");


            entity.HasIndex(e => e.IdProduct, "IX_Review_id_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Text)
                .HasMaxLength(500)
                .HasColumnName("text");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_Review_Product");

        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.IdOrder, "IX_User_id_order");

            entity.HasIndex(e => e.IdReview, "IX_User_id_review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Access).HasMaxLength(50);
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdReview).HasColumnName("id_review");
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_User_Order");

            entity.HasOne(d => d.IdReviewNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdReview)
                .HasConstraintName("FK_User_Review");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
