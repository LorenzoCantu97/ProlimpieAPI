using Microsoft.AspNetCore.Identity;
using ProlimpieAPI.Interfaces;

namespace ProlimpieAPI.Models.SysAdmin
{
    public class ApplicationRole : IdentityRole<int>, IAuditable
    {
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}
