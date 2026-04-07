using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas.Clientes
{
    public class ClientesComerciales : IAuditable
    {
        public int Id { get; set; }
        public required int ClientesId { get; set; }
        public required int ListasPreciosId { get; set; }
        public required int Descuento { get; set; }
        public required int MonedasId_Cliente { get; set; }
        public required int MonedasId_Docs { get; set; }
        public required int CondicionesPagosId { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Clientes Cliente { get; set; }
        //public required ListasPrecios ListaPrecio { get; set; }
        public required Monedas MonedaCliente { get; set; }
        public required Monedas MonedaDocumentos { get; set; }
        public required CondicionesPagos CondicionPago { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
