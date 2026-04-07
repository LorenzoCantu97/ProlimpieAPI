using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas
{
    public class Prospectos : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int ContactosId { get; set; }
        public required int OrganizacionesId { get; set; }
        public required decimal Valor { get; set; }
        public required int MonedasId { get; set; }
        public required int PrioridadesId { get; set; }
        public required bool Activo { get; set; }
        public required bool Publico { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Contactos Contacto { get; set; }
        public required Organizaciones Organizacion { get; set; }
        public required Monedas Moneda { get; set; }
        public required Prioridades Prioridad { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
