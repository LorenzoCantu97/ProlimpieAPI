using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General.Empresa;
using ProlimpieAPI.Models.General.Entidades;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService _currentUserService;

        public AppDbContext (
            DbContextOptions<AppDbContext> options,
            ICurrentUserService currentUserService
        ) : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region TABLAS
        public DbSet<Empresas> Empresas { get; set; }
        #endregion TABLAS

        #region CONFIGURACIONES

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userId = _currentUserService.UserId;
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedById = userId;
                    entry.Entity.UpdatedById = userId;
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedById = userId;
                    entry.Entity.UpdatedAt = now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        // Para crear relaciones de navegación
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* RELACIONES */
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.CreatedBy)
                .WithMany()
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.UpdatedBy)
                .WithMany()
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Entidades>()
                .HasOne(e => e.TiposEntidades)
                .WithMany(t => t.Entidades)
                .HasForeignKey(e => e.TiposEntidadesId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion CONFIGURACIONES
    }
}
