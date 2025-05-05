using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect.Data;

public partial class AgriEnergyConnectContext : DbContext
{
    public AgriEnergyConnectContext()
    {
    }

    public AgriEnergyConnectContext(DbContextOptions<AgriEnergyConnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FarmingResource> FarmingResources { get; set; }

    public virtual DbSet<MarketplaceItem> MarketplaceItems { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TROYLAPTOP\\SQLEXPRESS;Database=AgriEnergyConnect;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FarmingResource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__FarmingR__4ED1814FE77BFC59");

            entity.ToTable("FarmingResource");

            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.FarmingResources)
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("FK__FarmingRe__Uploa__412EB0B6");
        });

        modelBuilder.Entity<MarketplaceItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Marketpl__727E83EB44A69A9C");

            entity.ToTable("MarketplaceItem");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Provider).WithMany(p => p.MarketplaceItems)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__Marketpla__Provi__440B1D61");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79AE2CB343A7");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Item).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Review__ItemID__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Review__UserID__46E78A0C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC8CCE594D");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534E1FED758").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleID__3E52440B");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__UserRole__8AFACE3AE0F7CC76");

            entity.ToTable("UserRole");

            entity.HasIndex(e => e.RoleName, "UQ__UserRole__8A2B6160CC459FA4").IsUnique();

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.CanAddFarmerProfiles).HasDefaultValue(false);
            entity.Property(e => e.CanAddProducts).HasDefaultValue(false);
            entity.Property(e => e.CanViewAndFilterProducts).HasDefaultValue(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
