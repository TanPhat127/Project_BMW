using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

public partial class User
{
    [Key]
    public Guid Id { get; set; }

    [Column("userName")]
    public string UserName { get; set; } = null!;

    [Column("birthDay")]
    public DateTime BirthDay { get; set; }

    [Column("diaChi")]
    public string DiaChi { get; set; } = null!;

    [Column("phoneNumber")]
    public string PhoneNumber { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("password")]
    public string Password { get; set; } = null!;

    [Column("gioiTinh")]
    public string GioiTinh { get; set; } = null!;

    [Column("vaitro")]
    public string Vaitro { get; set; } = null!;
}
