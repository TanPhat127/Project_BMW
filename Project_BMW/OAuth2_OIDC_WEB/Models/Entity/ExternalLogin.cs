using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

public partial class ExternalLogin
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(50)]
    public string Provider { get; set; } = null!;

    [StringLength(255)]
    public string ProviderUserId { get; set; } = null!;

    public string? AccessToken { get; set; }

    public DateTime? CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ExternalLogins")]
    public virtual User User { get; set; } = null!;
}
