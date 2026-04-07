using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Ubicaciones
{
    public class Colonias : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int CodigosPostalesId { get; set; }
        public required bool Activo { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required CodigosPostales CodigoPostal { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
