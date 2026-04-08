using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Telefonos
{
    public class Telefonos : IAuditable
    {
        public int Id { get; set; }
        public required int PaisesId { get; set; }
        public required string Telefono { get; set; }
        public required int TiposTelefonosId { get; set; }
        public required bool Activo { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
