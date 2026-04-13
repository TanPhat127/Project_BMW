using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

[Table("PhienDangNhap")]
public partial class PhienDangNhap
{
    [Key]
    [Column("ID")]
    public Guid Id { get; set; }

    [Column("ID_NguoiDung")]
    public int? IdNguoiDung { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ThoiDiemDangNhap { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ThoiDiemHetHan { get; set; }

    [Column("DiaChiIP")]
    [StringLength(50)]
    public string? DiaChiIp { get; set; }

    [StringLength(255)]
    public string? ThietBi { get; set; }

    [StringLength(50)]
    public string? NhaCungCap { get; set; }

    [ForeignKey("IdNguoiDung")]
    [InverseProperty("PhienDangNhaps")]
    public virtual UserInfo? IdNguoiDungNavigation { get; set; }
}
