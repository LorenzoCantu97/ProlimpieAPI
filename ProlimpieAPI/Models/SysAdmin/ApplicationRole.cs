using Microsoft.AspNetCore.Identity;
using ProlimpieAPI.Interfaces;

namespace ProlimpieAPI.Models.SysAdmin
{
    public class ApplicationRole : IdentityRole<int>, IAuditable
    {
        #region Constructores
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
        #endregion Constructores

        public int? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
