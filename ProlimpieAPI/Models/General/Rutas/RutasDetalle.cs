using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Rutas
{
    public class RutasDetalle : IAuditable
    {
        public int Id { get; set; }
        public required int RutasId { get; set; }
        public required int DireccionesId { get; set; }
        public required int Orden { get; set; }
        public required DateTime HoraEstimada { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Rutas Ruta { get; set; }
        public required Direcciones.Direcciones Direccion { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
