using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SAT;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas.Clientes
{
    public class ClientesFiscales : IAuditable
    {
        public int Id { get; set; }
        public required int ClientesId { get; set; }
        public required string RFC { get; set; }
        public required string CURP { get; set; }
        public required string DenominacionComercial { get; set; }
        public required string RepresentanteLegal { get; set; }
        public required int RegimenesFiscalesId { get; set; }
        public required int UsosCFDIId { get; set; }
        public required int FormasPagoId { get; set; }
        public required int MetodosPagosId { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Clientes Cliente { get; set; }
        public required RegimenesFiscales RegimenFiscal { get; set; }
        public required UsosCFDI UsoCFDI { get; set; }
        public required FormasPagos FormaPago { get; set; }
        public required MetodosPagos MetodosPagos { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
