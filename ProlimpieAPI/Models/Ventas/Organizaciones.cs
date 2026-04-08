using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General;
using ProlimpieAPI.Models.General.Entidades;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas
{
    public class Organizaciones : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int EntidadesId { get; set; }
        public required int PrioridadesId { get; set; }
        public required bool Activo { get; set; }
        public required bool Publico { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Entidades Entidad { get; set; }
        public required Prioridades Prioridad { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
