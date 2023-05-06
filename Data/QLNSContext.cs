﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QLNS.Models;

namespace QLNS.Data
{
    public partial class QLNSContext : DbContext
    {
        public QLNSContext()
        {
        }

        public QLNSContext(DbContextOptions<QLNSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bangcap> Bangcaps { get; set; } = null!;
        public virtual DbSet<Baocao> Baocaos { get; set; } = null!;
        public virtual DbSet<Chucvu> Chucvus { get; set; } = null!;
        public virtual DbSet<CtKehoach> CtKehoaches { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Lienhe> Lienhes { get; set; } = null!;
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Phongban> Phongbans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\DELL;Database=QLNS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bangcap>(entity =>
            {
                entity.HasKey(e => e.MaBangCap)
                    .HasName("PK__BANGCAP__5CA48D4BC30A3729");

                entity.ToTable("BANGCAP");

                entity.Property(e => e.MaBangCap)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenBangCap).HasMaxLength(20);
            });

            modelBuilder.Entity<Baocao>(entity =>
            {
                entity.HasKey(e => e.IdbaoCao)
                    .HasName("PK__BAOCAO__BC216EF0B295D6BE");

                entity.ToTable("BAOCAO");

                entity.Property(e => e.IdbaoCao).HasColumnName("IDBaoCao");

                entity.Property(e => e.Idlh).HasColumnName("IDLH");

                entity.Property(e => e.KhchamSoc).HasColumnName("KHChamSoc");

                entity.Property(e => e.KhtimKiem).HasColumnName("KHTimKiem");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.MoTaCv).HasColumnName("MoTaCV");

                entity.Property(e => e.NgayLap).HasColumnType("date");

                entity.HasOne(d => d.IdlhNavigation)
                    .WithMany(p => p.Baocaos)
                    .HasForeignKey(d => d.Idlh)
                    .HasConstraintName("fk_LH");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Baocaos)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("fk_makh");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Baocaos)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("fk_manv");
            });

            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.MaChucVu)
                    .HasName("PK__ChucVu__D463953397DC581C");

                entity.ToTable("CHUCVU");

                entity.Property(e => e.MaChucVu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenChucVu).HasMaxLength(50);
            });

            modelBuilder.Entity<CtKehoach>(entity =>
            {
                entity.HasKey(e => e.IdkeHoach)
                    .HasName("PK__CT_KEHOA__936F11C80C25F6CC");

                entity.ToTable("CT_KEHOACH");

                entity.Property(e => e.IdkeHoach).HasColumnName("IDKeHoach");

                entity.Property(e => e.Idlh).HasColumnName("IDLH");

                entity.Property(e => e.KhchamSoc).HasColumnName("KHChamSoc");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.MoTaCv).HasColumnName("MoTaCV");

                entity.Property(e => e.NgayLap).HasColumnType("date");

                entity.Property(e => e.SoKhtn).HasColumnName("SoKHTN");

                entity.HasOne(d => d.IdlhNavigation)
                    .WithMany(p => p.CtKehoaches)
                    .HasForeignKey(d => d.Idlh)
                    .HasConstraintName("fk_lienhe");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.CtKehoaches)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("fk_khachhang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.CtKehoaches)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("fk_nhanvien");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KHACHHAN__2725CF1E1410E253");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.DiaChiCongTy).HasMaxLength(100);

                entity.Property(e => e.DiaChiLienHe).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaSoThue)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenCongty).HasMaxLength(100);

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<Lienhe>(entity =>
            {
                entity.HasKey(e => e.Idlh)
                    .HasName("PK__LIENHE__B87DF986AF2473F0");

                entity.ToTable("LIENHE");

                entity.Property(e => e.Idlh).HasColumnName("IDLH");

                entity.Property(e => e.SoKhlh).HasColumnName("SoKHLH");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.ToTable("NGUOIDUNG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Account)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Nguoidungs)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("fk_nv_user");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NHANVIEN__2725D70A4A5455F0");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CCCD");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MaChucVu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhongBan)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayCap).HasColumnType("date");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.NoiCap).HasMaxLength(50);

                entity.Property(e => e.NoiSinh).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.MaChucVuNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.MaChucVu)
                    .HasConstraintName("fk_ChucVu");

                entity.HasOne(d => d.MaPhongBanNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.MaPhongBan)
                    .HasConstraintName("fk_phongban");
            });

            modelBuilder.Entity<Phongban>(entity =>
            {
                entity.HasKey(e => e.MaPhongBan)
                    .HasName("PK__PHONGBAN__D0910CC882699578");

                entity.ToTable("PHONGBAN");

                entity.Property(e => e.MaPhongBan)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenPhongBan).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
