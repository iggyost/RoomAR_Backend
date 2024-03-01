using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_RoomAr.ApplicationData;

public partial class RoomArDbContext : DbContext
{
    public RoomArDbContext()
    {
    }

    public RoomArDbContext(DbContextOptions<RoomArDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Furniture> Furnitures { get; set; }

    public virtual DbSet<FurnituresCart> FurnituresCarts { get; set; }

    public virtual DbSet<FurnituresColor> FurnituresColors { get; set; }

    public virtual DbSet<FurnituresPhoto> FurnituresPhotos { get; set; }

    public virtual DbSet<FurnituresReview> FurnituresReviews { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ViewUserCart> ViewUserCarts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IgorPC\\SQLEXPRESS;Database=RoomArDb;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carts_Users");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.Property(e => e.ColorId).HasColumnName("color_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Furniture>(entity =>
        {
            entity.Property(e => e.FurnitureId).HasColumnName("furniture_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost");
            entity.Property(e => e.CoverPhoto).HasColumnName("cover_photo");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.Category).WithMany(p => p.Furnitures)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Furnitures_Categories");
        });

        modelBuilder.Entity<FurnituresCart>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.FurnitureId).HasColumnName("furniture_id");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_cost");

            entity.HasOne(d => d.Cart).WithMany(p => p.FurnituresCarts)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FurnituresCarts_Carts");

            entity.HasOne(d => d.Furniture).WithMany(p => p.FurnituresCarts)
                .HasForeignKey(d => d.FurnitureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FurnituresCarts_Furnitures");
        });

        modelBuilder.Entity<FurnituresColor>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColorId).HasColumnName("color_id");
            entity.Property(e => e.FurnitureId).HasColumnName("furniture_id");

            entity.HasOne(d => d.Color).WithMany(p => p.FurnituresColors)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FurnituresColors_Colors");

            entity.HasOne(d => d.Furniture).WithMany(p => p.FurnituresColors)
                .HasForeignKey(d => d.FurnitureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FurnituresColors_Furnitures");
        });

        modelBuilder.Entity<FurnituresPhoto>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FurnitureId).HasColumnName("furniture_id");
            entity.Property(e => e.PhotoId).HasColumnName("photo_id");

            entity.HasOne(d => d.Furniture).WithMany(p => p.FurnituresPhotos)
                .HasForeignKey(d => d.FurnitureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FurnituresPhotos_Furnitures");

            entity.HasOne(d => d.Photo).WithMany(p => p.FurnituresPhotos)
                .HasForeignKey(d => d.PhotoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FurnituresPhotos_Photos");
        });

        modelBuilder.Entity<FurnituresReview>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FurnitureId).HasColumnName("furniture_id");
            entity.Property(e => e.ReviewId).HasColumnName("review_id");

            entity.HasOne(d => d.Furniture).WithMany(p => p.FurnituresReviews)
                .HasForeignKey(d => d.FurnitureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FurnituresReviews_Furnitures");

            entity.HasOne(d => d.Review).WithMany(p => p.FurnituresReviews)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FurnituresReviews_Reviews");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.Property(e => e.PhotoId).HasColumnName("photo_id");
            entity.Property(e => e.Photo1).HasColumnName("photo");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.ReviewText)
                .HasMaxLength(500)
                .HasColumnName("review_text");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(30)
                .HasColumnName("phone_num");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<ViewUserCart>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewUserCart");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.CoverPhoto).HasColumnName("cover_photo");
            entity.Property(e => e.FurnitureId).HasColumnName("furniture_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_cost");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
