using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

[Table("TokenNguoiDung")]
public partial class TokenNguoiDung
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_NguoiDung")]
    public int? IdNguoiDung { get; set; }

    public string? AccessToken { get; set; }

    public string? IdToken { get; set; }

    public string? RefreshToken { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ThoiGianHetHan { get; set; }

    [StringLength(50)]
    public string? NhaCungCap { get; set; }

    [ForeignKey("IdNguoiDung")]
    [InverseProperty("TokenNguoiDungs")]
    public virtual UserInfo? IdNguoiDungNavigation { get; set; }
}
