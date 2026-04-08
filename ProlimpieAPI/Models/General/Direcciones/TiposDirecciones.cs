using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Direcciones
{
    public class TiposDirecciones : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public ICollection<Direcciones> Direcciones { get; set; } = new List<Direcciones>();
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
