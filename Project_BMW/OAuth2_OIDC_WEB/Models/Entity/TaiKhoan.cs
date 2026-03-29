using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

[Table("TaiKhoan")]
public partial class TaiKhoan
{
    [Key]
    public Guid Id { get; set; }

    [Column("userName")]
    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [Column("birthDay")]
    public DateTime BirthDay { get; set; }

    [Column("diaChi")]
    [StringLength(200)]
    public string DiaChi { get; set; } = null!;

    [Column("phoneNumber")]
    [StringLength(15)]
    public string PhoneNumber { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("password")]
    [StringLength(100)]
    public string Password { get; set; } = null!;

    [Column("gioiTinh")]
    public string GioiTinh { get; set; } = null!;

    [Column("vaitro")]
    public string Vaitro { get; set; } = null!;
}
