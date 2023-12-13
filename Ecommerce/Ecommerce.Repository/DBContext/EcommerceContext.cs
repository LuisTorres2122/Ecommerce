using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ecommerce.Model;

namespace Ecommerce.Repository.DBConext
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<DetailsSale> DetailsSales { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__79D361B6C2A5E23A");

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nameCategory");
            });

            modelBuilder.Entity<DetailsSale>(entity =>
            {
                entity.HasKey(e => e.IdDetailSale)
                    .HasName("PK__DetailsS__D072342E6F174857");

                entity.ToTable("DetailsSale");

                entity.Property(e => e.IdDetailSale).HasColumnName("idDetailSale");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.IdSale).HasColumnName("idSale");

                entity.Property(e => e.QuantityProduct).HasColumnName("quantityProduct");

                entity.Property(e => e.TotalProduct)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("totalProduct");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.DetailsSales)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__DetailsSa__idPro__44FF419A");

                entity.HasOne(d => d.IdSaleNavigation)
                    .WithMany(p => p.DetailsSales)
                    .HasForeignKey(d => d.IdSale)
                    .HasConstraintName("FK__DetailsSa__idSal__440B1D61");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__5EEC79D10762E3C3");

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.CreatedDateProduct)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDateProduct")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DescriptionProduct)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("descriptionProduct");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.ImageProduct)
                    .IsUnicode(false)
                    .HasColumnName("imageProduct");

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameProduct");

                entity.Property(e => e.OfferPriceProduct)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("offerPriceProduct");

                entity.Property(e => e.PriceProduct)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("priceProduct");

                entity.Property(e => e.QuantityProduct).HasColumnName("quantityProduct");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Product__idCateg__398D8EEE");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.IdSale)
                    .HasName("PK__Sale__C4AEB1984A287568");

                entity.ToTable("Sale");

                entity.Property(e => e.IdSale).HasColumnName("idSale");

                entity.Property(e => e.CreatedDateSale)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDateSale")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.TotalSale)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("totalSale");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Sale__idUser__403A8C7D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__3717C982CD1FB4FE");

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.CreatedDateUser)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDateUser")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailUser");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameUser");

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordUser");

                entity.Property(e => e.RolUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rolUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
