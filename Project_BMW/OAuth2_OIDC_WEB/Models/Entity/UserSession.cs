using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

public partial class UserSession
{
    [Key]
    public Guid Id { get; set; }

    public int UserId { get; set; }

    [StringLength(50)]
    public string? LoginProvider { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? ExpireTime { get; set; }

    [StringLength(50)]
    public string? IpAddress { get; set; }

    [StringLength(500)]
    public string? UserAgent { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserSessions")]
    public virtual User User { get; set; } = null!;
}
