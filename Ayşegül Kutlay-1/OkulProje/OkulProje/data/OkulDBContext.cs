using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OkulProje.data
{
    public partial class OkulDBContext : DbContext
    {
        public OkulDBContext()
        {
        }

        public OkulDBContext(DbContextOptions<OkulDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DersTab> DersTabs { get; set; } = null!;
        public virtual DbSet<OgrenciDersTab> OgrenciDersTabs { get; set; } = null!;
        public virtual DbSet<OgrenciTab> OgrenciTabs { get; set; } = null!;
        public virtual DbSet<OkulYonetimTab> OkulYonetimTabs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=OkulDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DersTab>(entity =>
            {
                entity.ToTable("DersTab");

                entity.Property(e => e.Ad).HasMaxLength(50);

                entity.HasOne(d => d.OkulYonetim)
                    .WithMany(p => p.DersTabs)
                    .HasForeignKey(d => d.OkulYonetimId)
                    .HasConstraintName("FK_DersTab_OkulYonetimTab");
            });

            modelBuilder.Entity<OgrenciDersTab>(entity =>
            {
                entity.ToTable("OgrenciDersTab");

                entity.HasOne(d => d.Ders)
                    .WithMany(p => p.OgrenciDersTabs)
                    .HasForeignKey(d => d.DersId)
                    .HasConstraintName("FK_OgrenciDersTab_DersTab");

                entity.HasOne(d => d.Ogrenci)
                    .WithMany(p => p.OgrenciDersTabs)
                    .HasForeignKey(d => d.OgrenciId)
                    .HasConstraintName("FK_OgrenciDersTab_OgrenciTab");
            });

            modelBuilder.Entity<OgrenciTab>(entity =>
            {
                entity.ToTable("OgrenciTab");

                entity.Property(e => e.AdSoyad).HasMaxLength(50);

                entity.Property(e => e.Bolum).HasMaxLength(50);

                entity.Property(e => e.Dtarih)
                    .HasColumnType("date")
                    .HasColumnName("DTarih");

                entity.Property(e => e.KayitTarih).HasColumnType("date");
            });

            modelBuilder.Entity<OkulYonetimTab>(entity =>
            {
                entity.ToTable("OkulYonetimTab");

                entity.Property(e => e.AdSoyad).HasMaxLength(50);

                entity.Property(e => e.Gorevi).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
