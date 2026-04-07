using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Empresa
{
    public class Empresas : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string RFC { get; set; }
        public required string RazonSocial { get; set; }
        public required bool Activo { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public ICollection<SucursalesEmpresas>? Sucursales { get; set; } = new List<SucursalesEmpresas>();
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}