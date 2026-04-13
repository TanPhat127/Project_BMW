using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

[Table("TaiKhoanNoiBo")]
[Index("Username", Name = "UQ__TaiKhoan__536C85E4E59C95AA", IsUnique = true)]
public partial class TaiKhoanNoiBo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_NguoiDung")]
    public int? IdNguoiDung { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(500)]
    public string PassHash { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? LanDangNhapCuoi { get; set; }

    [ForeignKey("IdNguoiDung")]
    [InverseProperty("TaiKhoanNoiBos")]
    public virtual UserInfo? IdNguoiDungNavigation { get; set; }
}
