using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Rutas
{
    public class Rutas : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required DateTime FechaEstablecida { get; set; }
        public required string UsuariosId_Delegado { get; set; }
        public required int StatusId { get; set; }
        public required int TiposRutasId { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required ApplicationUser UsuarioDelegado { get; set; }
        public required Status Status { get; set; }
        public required TiposRutas TipoRuta { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
