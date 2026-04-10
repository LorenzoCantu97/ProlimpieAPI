using Microsoft.EntityFrameworkCore;
using ProlimpieAPI.Data;
using ProlimpieAPI.Models._DTO.SysAdmin;

namespace ProlimpieAPI.Services.sysAdmin
{
    public interface IHistorialService
    {
        Task<List<HistorialDTO>> GetHistorialGrid();
    }

    public class HistorialService : IHistorialService
    {
        private readonly AppDbContext _appDbContext;
        public HistorialService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<HistorialDTO>> GetHistorialGrid()
        {
            return await _appDbContext.Historial
            .GroupJoin(_appDbContext.Users,
                historial => historial.UserId,
                user => user.Id,
                (historial, users) => new { historial, createdUser = users.FirstOrDefault() }
            )
            .Select(x => new HistorialDTO
            {
                Id = x.historial.Id,
                Modulo = x.historial.Modulo != null ? x.historial.Modulo.Nombre : string.Empty,
                Pagina = x.historial.Pagina != null ? x.historial.Pagina.Nombre : string.Empty,
                Action = x.historial.Action,
                UserName = x.createdUser != null ? x.createdUser.Nombre : string.Empty,
                Timestamp = x.historial.Timestamp,
            })
            .ToListAsync();
        }
    }
}
