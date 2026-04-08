using Microsoft.AspNetCore.Identity;
using ProlimpieAPI.Interfaces;

namespace ProlimpieAPI.Models.SysAdmin
{
    public class ApplicationRoleClaim : IdentityRoleClaim<int>, IAuditable
    {
        public int? ModulosId { get; set; }
        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public Modulos? Modulo { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
