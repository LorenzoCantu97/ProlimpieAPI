using Microsoft.AspNetCore.Identity;
using ProlimpieAPI.Interfaces;

namespace ProlimpieAPI.Models.SysAdmin
{
    public class ApplicationUser : IdentityUser, IAuditable
    {
        public required string Nombre { get; set; }
        public string? SegundoNombre { get; set; }
        public required string ApellidoPaterno { get; set; }
        public required string ApellidoMaterno { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required DateTime FechaIngreso { get; set; }
        public required int SucursalesEmpresasId { get; set; }
        public required int EntidadesId { get; set; }
        public required bool Activo { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
