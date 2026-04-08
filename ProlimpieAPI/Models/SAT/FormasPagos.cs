using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.SAT
{
    public class FormasPagos : IAuditable
    {
        public int Id { get; set; }
        public required string ClaveSAT { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
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
