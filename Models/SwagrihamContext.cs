using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Swagriham.Models;

public partial class SwagrihamContext : DbContext
{
    public SwagrihamContext()
    {
    }

    public SwagrihamContext(DbContextOptions<SwagrihamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Flat> Flats { get; set; }

    public virtual DbSet<FlatPhoto> FlatPhotos { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=_AIMERSTAR_\\HARSHILMSSQL;Initial Catalog=Swagriham;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentId).HasName("PK__Agent__9AC3BFD173EC5AA3");

            entity.ToTable("Agent");

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.AgencyName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Agents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Agent__UserID__59FA5E80");
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId).HasName("PK__Amenitie__842AF52B211CCCD8");

            entity.Property(e => e.AmenityId).HasColumnName("AmenityID");
            entity.Property(e => e.AmenityName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.InquiryId).HasName("PK__Contact__05E6E7EF23F8DB1C");

            entity.ToTable("Contact");

            entity.Property(e => e.InquiryId).HasColumnName("InquiryID");
            entity.Property(e => e.ContactDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FlatId).HasColumnName("FlatID");
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.ResponseStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Flat).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.FlatId)
                .HasConstraintName("FK__Contact__FlatID__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Contact__UserID__4F7CD00D");
        });

        modelBuilder.Entity<Flat>(entity =>
        {
            entity.HasKey(e => e.FlatId).HasName("PK__Flat__7CD6ED91A8D3A30F");

            entity.ToTable("Flat");

            entity.Property(e => e.FlatId).HasColumnName("FlatID");
            entity.Property(e => e.Bhk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BHK");
            entity.Property(e => e.CarpetArea).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FacingDirection)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FurnishingStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.MaintenanceCharges).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Parking)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PossessionStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Reranumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RERANumber");
            entity.Property(e => e.SuperBuiltUpArea).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Location).WithMany(p => p.Flats)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Flat_Location");

            entity.HasOne(d => d.User).WithMany(p => p.Flats)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Flat__UserID__403A8C7D");

            entity.HasMany(d => d.Amenities).WithMany(p => p.Flats)
                .UsingEntity<Dictionary<string, object>>(
                    "FlatAmenity",
                    r => r.HasOne<Amenity>().WithMany()
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__FlatAmeni__Ameni__45F365D3"),
                    l => l.HasOne<Flat>().WithMany()
                        .HasForeignKey("FlatId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__FlatAmeni__FlatI__44FF419A"),
                    j =>
                    {
                        j.HasKey("FlatId", "AmenityId").HasName("PK__FlatAmen__D49442C3D5B9579E");
                        j.ToTable("FlatAmenities");
                        j.IndexerProperty<int>("FlatId").HasColumnName("FlatID");
                        j.IndexerProperty<int>("AmenityId").HasColumnName("AmenityID");
                    });
        });

        modelBuilder.Entity<FlatPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__FlatPhot__21B7B582C5651B6A");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");
            entity.Property(e => e.FlatId).HasColumnName("FlatID");
            entity.Property(e => e.IsPrimary).HasDefaultValue(false);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PhotoURL");

            entity.HasOne(d => d.Flat).WithMany(p => p.FlatPhotos)
                .HasForeignKey(d => d.FlatId)
                .HasConstraintName("FK__FlatPhoto__FlatI__49C3F6B7");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477D3407838");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LocalityName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StateName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79AE7BFCE3C6");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FlatId).HasColumnName("FlatID");
            entity.Property(e => e.ReviewText).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Flat).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.FlatId)
                .HasConstraintName("FK__Review__FlatID__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Review__UserID__5535A963");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC58BC1C27");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D105344C513D93").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
