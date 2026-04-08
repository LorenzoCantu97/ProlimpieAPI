using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General;
using ProlimpieAPI.Models.General.Rutas;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas
{
    public class Visitas : IAuditable
    {
        public int Id { get; set; }
        public required int RutasDetalleId { get; set; }
        public required int TiposVisitasId { get; set; }
        public required int ProspectosId { get; set; }
        public required DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }
        public required int StatusId { get; set; }
        public required string Comentarios { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required RutasDetalle RutaDetalle { get; set; }
        public required TiposVisitas TipoVisita { get; set; }
        public required Prospectos Prospecto { get; set; }
        public required Status Status { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
