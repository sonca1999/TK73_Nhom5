using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLVT1.DAL.Models
{
    public partial class QLTV1Context : DbContext
    {
        public QLTV1Context()
        {
        }

        public QLTV1Context(DbContextOptions<QLTV1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctmuontra> Ctmuontra { get; set; }
        public virtual DbSet<Docgia> Docgia { get; set; }
        public virtual DbSet<Muontra> Muontra { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<Tacgia> Tacgia { get; set; }
        public virtual DbSet<Theloai> Theloai { get; set; }
        public virtual DbSet<Thethuvien> Thethuvien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTV2;Persist Security Info=True;User ID=sa;Password=1;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ctmuontra>(entity =>
            {
                entity.HasKey(e => new { e.MaMt, e.MaSach })
                    .HasName("PK__CTMUONTRA");

                entity.ToTable("CTMUONTRA");

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.MaMt).HasColumnName("MaMT");

                entity.Property(e => e.Ngaytra).HasColumnType("date");

                entity.HasOne(d => d.MaMtNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaMt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTMUONTRA__MaMT__1B0907CE");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTMUONTRA__MaSac__1BFD2C07");
            });

            modelBuilder.Entity<Docgia>(entity =>
            {
                entity.HasKey(e => e.MaDg)
                    .HasName("PK__DOCGIA__272586605F17A020");

                entity.ToTable("DOCGIA");

                entity.Property(e => e.MaDg)
                    .HasColumnName("MaDG");
                    

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TenDg)
                    .IsRequired()
                    .HasColumnName("TenDG")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaTheNavigation)
                    .WithMany(p => p.Docgia)
                    .HasForeignKey(d => d.MaThe)
                    .HasConstraintName("FK__DOCGIA__MaThe__1CF15040");
            });

            modelBuilder.Entity<Muontra>(entity =>
            {
                entity.HasKey(e => e.MaMt)
                    .HasName("PK__MUONTRA__2725DFD5C962805B");

                entity.ToTable("MUONTRA");

                entity.Property(e => e.MaMt)
                    .HasColumnName("MaMT");
                   

                entity.Property(e => e.Ngaymuon).HasColumnType("date");

                entity.HasOne(d => d.MaTheNavigation)
                    .WithMany(p => p.Muontra)
                    .HasForeignKey(d => d.MaThe)
                    .HasConstraintName("FK__MUONTRA__MaThe__1DE57479");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK__SACH__B235742D9B94EA02");

                entity.ToTable("SACH");

                entity.Property(e => e.MaSach).HasColumnName("MaSach");

                entity.Property(e => e.MaTg).HasColumnName("MaTG");

                entity.Property(e => e.MaTl).HasColumnName("MaTL");

                entity.Property(e => e.NamSx)
                    .HasColumnName("NamSX")
                    .HasColumnType("date");

                entity.Property(e => e.TenSach).HasMaxLength(50);

                entity.HasOne(d => d.MaTgNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTg)
                    .HasConstraintName("FK__SACH__MaTG__1ED998B2");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTl)
                    .HasConstraintName("FK__SACH__MaTL__1FCDBCEB");
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.MaTg)
                    .HasName("PK__TACGIA__2725007440470122");

                entity.ToTable("TACGIA");

                entity.Property(e => e.MaTg)
                    .HasColumnName("MaTG");
                    

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.TenTg)
                    .HasColumnName("TenTG")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTl)
                    .HasName("PK__THELOAI__27250071776BFAF4");

                entity.ToTable("THELOAI");

                entity.Property(e => e.MaTl)
                    .HasColumnName("MaTL");
                    

                entity.Property(e => e.TenTl)
                    .HasColumnName("TenTL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Thethuvien>(entity =>
            {
                entity.HasKey(e => e.MaThe)
                    .HasName("PK__THETHUVI__314EEAAF591275A8");

                entity.ToTable("THETHUVIEN");

                entity.Property(e => e.MaThe).HasColumnName("MaThe");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgayBd)
                    .HasColumnName("NgayBD")
                    .HasColumnType("date");

                entity.Property(e => e.NgayHh)
                    .HasColumnName("NgayHH")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
