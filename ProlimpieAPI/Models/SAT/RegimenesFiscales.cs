using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.SAT
{
    public class RegimenesFiscales : IAuditable
    {
        public int Id { get; set; }
        public required string ClaveSAT { get; set; }
        public required string Descripcion { get; set; }
        public required string TipoPersona { get; set; }
        public DateTime? VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }
        public bool Activo { get; set; }
        public string? CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
