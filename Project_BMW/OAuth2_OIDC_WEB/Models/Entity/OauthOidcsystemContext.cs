using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_OIDC_WEB.Models.Entity;

public partial class OauthOidcsystemContext : DbContext
{
    public OauthOidcsystemContext()
    {
    }

    public OauthOidcsystemContext(DbContextOptions<OauthOidcsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExternalLogin> ExternalLogins { get; set; }

    public virtual DbSet<LocalAccount> LocalAccounts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSession> UserSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExternalLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__External__3214EC07107710EB");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.ExternalLogins).HasConstraintName("FK_ExternalLogins_User");
        });

        modelBuilder.Entity<LocalAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LocalAcc__3214EC07CA948A92");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.LocalAccounts).HasConstraintName("FK_LocalAccounts_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07704B9C34");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<UserSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSess__3214EC0776DA1EA6");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LoginTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.UserSessions).HasConstraintName("FK_UserSessions_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
