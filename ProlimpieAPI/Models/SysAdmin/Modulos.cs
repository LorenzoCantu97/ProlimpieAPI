namespace ProlimpieAPI.Models.SysAdmin
{
    public class Modulos
    {
        public int Id { get; set;  }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    
        // Relaciones de navegación
        public ICollection<ApplicationRoleClaim>? RoleClaims { get; set; }
    }
}
