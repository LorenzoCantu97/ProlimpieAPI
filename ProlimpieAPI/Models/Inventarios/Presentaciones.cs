using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Inventarios
{
    public class Presentaciones : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int Cantidad { get; set; }
        public required int UnidadesMedidasId { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required UnidadesMedidas UnidadMedida { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }

    }
}
