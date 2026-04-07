using Microsoft.EntityFrameworkCore;
using ProlimpieAPI.Data;
using ProlimpieAPI.Models._DTO.SysAdmin;

namespace ProlimpieAPI.Services
{
    public interface IUsuariosService
    {
        Task<List<UsuariosDTO>> GetUsuariosGrid();
    }

    public class UsuariosService : IUsuariosService
    {
        private readonly AppDbContext _appDbContext;

        public UsuariosService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<UsuariosDTO>> GetUsuariosGrid()
        {
            return await _appDbContext.Users
                .Select(user => new UsuariosDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    NombreCompleto = $"{user.Nombre} {user.ApellidoPaterno} {user.ApellidoMaterno}",
                    Nombre = user.Nombre,
                    ApellidoPaterno = user.ApellidoPaterno,
                    ApellidoMaterno = user.ApellidoMaterno,
                    Email = user.Email,
                    Telefono = user.PhoneNumber,
                    FechaNacimiento = user.FechaNacimiento,
                    FechaIngreso = user.FechaIngreso,
                    SucursalesEmpresasId = user.SucursalesEmpresasId,
                    Activo = user.Activo
                })
                .ToListAsync();
        }

    }
}