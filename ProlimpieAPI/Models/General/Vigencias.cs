using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.General
{
    public class Vigencias : IAuditable
    {
        public int Id { get; set; }
        public required int PeriodosId { get; set; }
        public required int Cantidad { get; set; }
        public string? CreatedById { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedById { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Periodos Periodo { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
