

namespace ProlimpieAPI.Models
{
    public class Empresa
    {
        public int ID { get; set; }
        public required string Nombre { get; set; }
        public required string RFC { get; set; }
        public required string RazonSocial { get; set; }
        public required int Activo { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}