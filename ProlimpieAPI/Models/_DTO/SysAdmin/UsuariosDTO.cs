namespace ProlimpieAPI.Models._DTO.SysAdmin
{
    public class UsuariosDTO
    {
        public required string Id { get; set; }
        public string? UserName { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? SucursalesEmpresasId { get; set; }
        public bool Activo { get; set; }
    }
}
