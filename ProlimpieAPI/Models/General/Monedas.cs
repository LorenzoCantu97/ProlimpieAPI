using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General
{
    public class Monedas : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required char Simbolo { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
