using ProlimpieAPI.Models.General.Entidades;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Ventas.Clientes
{
    public class Clientes
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int EntidadesId { get; set; }
        public required int TiposClientesId { get; set; }
        public required int UsuariosId_Vendedor { get; set; }
        public required bool Activo { get; set; }
        public required int CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required int UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Entidades Entidad { get; set; }
        public required TiposClientes TipoCliente { get; set;}
        public required ApplicationUser Vendedor { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
