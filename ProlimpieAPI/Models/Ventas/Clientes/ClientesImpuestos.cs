using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas.Clientes
{
    public class ClientesImpuestos : IAuditable
    {
        public int Id { get; set; }
        public required int ClientesId { get; set; }
        public required decimal IVA { get; set; }
        public required decimal IESPS { get; set; }
        public required decimal RetISR { get; set; }
        public required decimal RetIVA { get; set; }
        public required int PorcentajeIVA { get; set; }
        public required int PorcentajeIESPS { get; set; }
        public required int PorcentajeRetISR { get; set; }
        public required int PorcentajeRetIVA { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Clientes Cliente { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
