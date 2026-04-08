using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General.Emails
{
    public class Emails : IAuditable
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required int TiposEmailsId { get; set; }
        public required bool Activo { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required TiposEmails TipoEmail { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
