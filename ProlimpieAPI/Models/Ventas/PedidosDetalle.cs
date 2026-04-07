using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.Inventarios;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas
{
    public class PedidosDetalle : IAuditable
    {
        public int Id { get; set; }
        public required int PedidosId { get; set; }
        public required int ArticulosId { get; set; }
        public required int Cantidad { get; set; }
        public required int PresentacionesId { get; set; }
        public required decimal PrecioUnitario { get; set; }
        public required decimal Descuento { get; set; }
        public required decimal ISR { get; set; }
        public required decimal IVA { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Pedidos Pedido { get; set; }
        public required Articulos Articulo { get; set; }
        public required Presentaciones Presentacion { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
