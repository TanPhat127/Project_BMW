using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

[Index("Username", Name = "UQ__LocalAcc__536C85E431A4C570", IsUnique = true)]
public partial class LocalAccount
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(500)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(500)]
    public string PasswordSalt { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("LocalAccounts")]
    public virtual User User { get; set; } = null!;
}
