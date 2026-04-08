using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Empresa
{
    public class SucursalesEmpresas : IAuditable
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int EmpresasId { get; set; }
        public required bool Activo { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // NAVEGACION
        public required Empresas Empresas { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}