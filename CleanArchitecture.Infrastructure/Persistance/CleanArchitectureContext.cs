using CleanArchitecture.SharedKernel.Modules.ApiKey;
using CleanArchitecture.SharedKernel.Modules.Jwt;
using CleanArchitecture.SharedKernel.Services.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public partial class CleanArchitectureContext : DbContext
    {
        public CleanArchitectureContext()
        {
        }

        public CleanArchitectureContext(DbContextOptions<CleanArchitectureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiKey> ApiKeys { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiKey>(entity =>
            {
                entity.HasKey(e => e.Token);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Token });

                entity.Property(e => e.Token).HasMaxLength(64);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
