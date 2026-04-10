namespace ProlimpieAPI.Models._DTO.SysAdmin
{
    public class UsuariosDTO
    {
        public required int Id { get; set; }
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
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class RolesDTO
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }    
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class AccesosDTO
    {
        public required int Id { get; set; }
        public string? Tipo { get; set; }
        public string? Modulo { get; set; }
        public string? Nombre { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }    
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class PermisosDTO
    {
        public required int Id { get; set; }
        public string? Tipo { get; set; }
        public string? Modulo { get; set; }
        public string? Nombre { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }    
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class HistorialDTO
    {
        public required int Id { get; set; }
        public string? Modulo { get; set; }
        public string? Pagina { get; set; }
        public string? Action { get; set; }
        public string? UserName { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
