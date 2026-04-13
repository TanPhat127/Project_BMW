using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

public partial class OauthOidcsystemContext : DbContext
{
    public OauthOidcsystemContext()
    {
    }

    public OauthOidcsystemContext(DbContextOptions<OauthOidcsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DangNhapNgoai> DangNhapNgoais { get; set; }

    public virtual DbSet<PhienDangNhap> PhienDangNhaps { get; set; }

    public virtual DbSet<TaiKhoanNoiBo> TaiKhoanNoiBos { get; set; }

    public virtual DbSet<TokenNguoiDung> TokenNguoiDungs { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DangNhapNgoai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DangNhap__3214EC27AE8D0A58");

            entity.Property(e => e.NgayLienKet).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.DangNhapNgoais)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DangNhapNgoai_NguoiDung");
        });

        modelBuilder.Entity<PhienDangNhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhienDan__3214EC27D728BA4C");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ThoiDiemDangNhap).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.PhienDangNhaps)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Phien_NguoiDung");
        });

        modelBuilder.Entity<TaiKhoanNoiBo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3214EC277DF7391E");

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.TaiKhoanNoiBos)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TaiKhoan_NguoiDung");
        });

        modelBuilder.Entity<TokenNguoiDung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TokenNgu__3214EC27ED0A56E6");

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.TokenNguoiDungs)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Token_NguoiDung");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserInfo__3214EC278836CE19");

            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
