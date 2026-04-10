using Microsoft.Identity.Client;

namespace ProlimpieAPI.Models.SysAdmin
{
    public class Paginas
    {
        public int Id { get; set; }
        public required int ModulosId { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? CreatedById { get; set;  }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Modulos Modulo { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
