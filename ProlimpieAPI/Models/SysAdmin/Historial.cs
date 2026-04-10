namespace ProlimpieAPI.Models.SysAdmin
{
    public class Historial
    {
        public int Id { get; set;  }
        public int? ModulosId { get; set; }
        public int? PaginasId { get; set; }
        public string? Action { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? Timestamp { get; set; }

        // Relaciones de navegación
        public Modulos? Modulo { get; set; }
        public Paginas? Pagina { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
