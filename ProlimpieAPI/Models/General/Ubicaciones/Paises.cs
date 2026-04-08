using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Ubicaciones
{
    public class Paises : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string CodigoIso2 { get; set; }
        public required string CodigoIso3 { get; set; }
        public required string CodigoTelefono { get; set; }
        public required int MonedasId { get; set; }
        public required bool Activo { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Monedas Moneda { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
