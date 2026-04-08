using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas.Clientes
{
    public class ClientesCredito : IAuditable
    {
        public int Id { get; set; }
        public required int ClientesId { get; set; }
        public required bool VentasCredito { get; set; }
        public required decimal LimiteCredito { get; set; }
        public required int DiasCredito { get; set; }
        public required int DescuentoProntoPago { get; set; }
        public required int DiasDescuentoProntoPago { get; set; }
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
