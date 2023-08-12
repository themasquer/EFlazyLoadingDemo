using System;
using System.Collections.Generic;
using EFlazyLoadingDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFlazyLoadingDemo.Contexts;

public partial class KursAdvancedDbContext : DbContext
{
    public KursAdvancedDbContext()
    {
    }

    public KursAdvancedDbContext(DbContextOptions<KursAdvancedDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bolum> Bolum { get; set; }

    public virtual DbSet<Ders> Ders { get; set; }

    public virtual DbSet<Ogrenci> Ogrenci { get; set; }

    public virtual DbSet<OgrenciDers> OgrenciDers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=KursAdvancedDB;trusted_connection=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bolum>(entity =>
        {
            entity.Property(e => e.Adi)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ders>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ders__3214EC0731C27678");

            entity.Property(e => e.Adi)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Icerik).IsUnicode(false);
        });

        modelBuilder.Entity<Ogrenci>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ogrenci__3214EC07444A0911");

            entity.Property(e => e.Adi).HasMaxLength(100);
            entity.Property(e => e.Soyadi)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Bolum).WithMany(p => p.Ogrenci)
                .HasForeignKey(d => d.BolumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ogrenci__BolumId__3F466844");
        });

        modelBuilder.Entity<OgrenciDers>(entity =>
        {
            entity.HasOne(d => d.Ders).WithMany(p => p.OgrenciDers)
                .HasForeignKey(d => d.DersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OgrenciDe__DersI__3D5E1FD2");

            entity.HasOne(d => d.Ogrenci).WithMany(p => p.OgrenciDers)
                .HasForeignKey(d => d.OgrenciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OgrenciDe__Ogren__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
