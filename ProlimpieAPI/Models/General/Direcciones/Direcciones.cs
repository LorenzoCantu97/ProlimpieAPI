using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General.Ubicaciones;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Direcciones
{
    public class Direcciones : IAuditable
    {
        public int Id { get; set; }
        public required int TiposDireccionesId { get; set; }
        public required int ColoniasId { get; set; }
        public required string Calle { get; set; }
        public string? EntreCalles_1 { get; set; }
        public string? EntreCalles_2 { get; set; }
        public required int NumeroInterior { get; set; }
        public int? NumeroExterior { get; set; }
        public required bool Activo { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required TiposDirecciones TipoDireccion { get; set; }
        public required Colonias Colonia { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
