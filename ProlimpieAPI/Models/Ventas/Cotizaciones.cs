using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General;
using ProlimpieAPI.Models.General.Direcciones;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas
{
    public class Cotizaciones : IAuditable
    {
        public int Id { get; set; }
        public required int CotizacionesDetalleId { get; set; }
        public required int ClientesId { get; set; }
        public required int DireccionesId { get; set; }
        public required int UsuariosId_Cotizacion { get; set; }
        public required int UsuariosId_Vendedor { get; set; }
        public required int TiemposEntregasId { get; set; }
        public required int MetodosEntregasId { get; set; }
        public required int CondicionesPagosId { get; set; }
        public required int VigenciasId { get; set; }
        public required int PrioridadesId { get; set; }
        public required int StatusId { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required CotizacionesDetalle Detalle { get; set; }
        public required Clientes.Clientes Cliente { get; set; }
        public required Direcciones Direccion { get; set; }
        public required ApplicationUser UsuarioCotizacion { get; set; }
        public required ApplicationUser UsuarioVendedor { get; set; }
        public required TiemposEntregas TiempoEntrega { get; set; }
        public required MetodosEntregas MetodoEntrega { get; set; }
        public required CondicionesPagos CondicionPago { get; set; }
        public required Vigencias Vigencia { get; set; }
        public required Status Status { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
