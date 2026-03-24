

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProlimpieAPI.Models
{
    public class SucursalEmpresa
    {
        public int ID { get; set; }
        public required string Nombre { get; set; }
        public required int EmpresasId { get; set; }
        public required int Activo { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}