using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General;
using ProlimpieAPI.Models.General.Direcciones;
using ProlimpieAPI.Models.Inventarios;
using ProlimpieAPI.Models.SAT;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas
{
    public class Pedidos : IAuditable
    {
        public int Id { get; set; }
        public int? CotizacionesId { get; set; }
        public required int ClientesId { get; set; }
        public required int DireccionesId { get; set; }
        public required int UsuariosId_Vendedor { get; set; }
        public string? OrdenCompra_Cliente { get; set; }
        public required int TransportesId { get; set; }
        public required int CondicionesPagosId { get; set; }
        public required int FormasPagosId { get; set; }
        public required int PrioridadesId { get; set; }
        public required int StatusId { get; set; }
        public string? Comentarios { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public Cotizaciones? Cotizacion { get; set; }
        public required Clientes.Clientes Cliente { get; set; }
        public required Direcciones Direccion { get; set; }
        public required ApplicationUser Vendedor { get; set; }
        public required Transportes Transporte { get; set; }
        public required CondicionesPagos CondicionPago { get; set; }
        public required FormasPagos FormasPagos { get; set; }
        public required Prioridades Prioridades { get; set; }
        public required Status Status { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
