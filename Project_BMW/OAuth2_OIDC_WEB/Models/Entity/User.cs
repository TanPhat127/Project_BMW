using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

[Index("Email", Name = "UQ__Users__A9D10534318B0062", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }

    [StringLength(255)]
    public string DisplayName { get; set; } = null!;

    [StringLength(500)]
    public string? PictureUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ExternalLogin> ExternalLogins { get; set; } = new List<ExternalLogin>();

    [InverseProperty("User")]
    public virtual ICollection<LocalAccount> LocalAccounts { get; set; } = new List<LocalAccount>();

    [InverseProperty("User")]
    public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
}
