using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

[Table("DangNhapNgoai")]
public partial class DangNhapNgoai
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_NguoiDung")]
    public int? IdNguoiDung { get; set; }

    [StringLength(50)]
    public string NhaCungCap { get; set; } = null!;

    [StringLength(255)]
    public string MaNguoiDungNgoai { get; set; } = null!;

    [StringLength(255)]
    public string? EmailNgoai { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayLienKet { get; set; }

    [ForeignKey("IdNguoiDung")]
    [InverseProperty("DangNhapNgoais")]
    public virtual UserInfo? IdNguoiDungNavigation { get; set; }
}
