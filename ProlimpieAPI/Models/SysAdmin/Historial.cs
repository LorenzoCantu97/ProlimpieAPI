namespace ProlimpieAPI.Models.SysAdmin
{
    public class Historial
    {
        public int Id { get; set;  }
        public string? ModulosId { get; set; }
        public string? Action { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? Timestamp { get; set; }

        // Relaciones de navegación
        public Modulos? Modulo { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
