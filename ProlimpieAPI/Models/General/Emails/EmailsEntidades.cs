using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.General.Entidades;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Emails
{
    public class EmailsEntidades : IAuditable
    {
        public int Id { get; set; }
        public required int EmailsId { get; set; }
        public required int EntidadesId { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Emails Email { get; set; }
        public required Entidades.Entidades Entidad { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
