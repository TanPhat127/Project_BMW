using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

[Table("UserInfo")]
[Index("Email", Name = "UQ__UserInfo__A9D105348201A101", IsUnique = true)]
public partial class UserInfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }

    [StringLength(255)]
    public string? HoTen { get; set; }

    [StringLength(500)]
    public string? Hinh { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayTao { get; set; }

    public bool? TrangThai { get; set; }

    [InverseProperty("IdNguoiDungNavigation")]
    public virtual ICollection<DangNhapNgoai> DangNhapNgoais { get; set; } = new List<DangNhapNgoai>();

    [InverseProperty("IdNguoiDungNavigation")]
    public virtual ICollection<PhienDangNhap> PhienDangNhaps { get; set; } = new List<PhienDangNhap>();

    [InverseProperty("IdNguoiDungNavigation")]
    public virtual ICollection<TaiKhoanNoiBo> TaiKhoanNoiBos { get; set; } = new List<TaiKhoanNoiBo>();

    [InverseProperty("IdNguoiDungNavigation")]
    public virtual ICollection<TokenNguoiDung> TokenNguoiDungs { get; set; } = new List<TokenNguoiDung>();
}
