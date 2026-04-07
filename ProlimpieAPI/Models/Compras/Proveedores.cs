namespace ProlimpieAPI.Models.Compras
{
    public class Proveedores
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int EntidadesId { get; set; }
        public required int CreatedBy { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required int UpdatedBy { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}
