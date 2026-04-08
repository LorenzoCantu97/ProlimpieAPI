using Microsoft.EntityFrameworkCore;
using ProlimpieAPI.Data;
using ProlimpieAPI.Models._DTO.SysAdmin;

namespace ProlimpieAPI.Services.sysAdmin
{
    public interface IRolesService
    {
        Task<List<RolesDTO>> GetRolesGrid();
    }

    public class RolesService : IRolesService
    {
        private readonly AppDbContext _appDbContext;
        public RolesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<RolesDTO>> GetRolesGrid()
        {
            return await _appDbContext.Roles
                .Select(rol => new RolesDTO
                {
                    Id = rol.Id.ToString(),
                    Name = rol.Name,
                    CreatedBy = rol.CreatedBy != null ? rol.CreatedBy.Nombre : null,
                    CreatedAt = rol.CreatedAt,
                    UpdatedBy = rol.UpdatedBy != null ? rol.UpdatedBy.Nombre : null,
                    UpdatedAt = rol.UpdatedAt
                })
                .ToListAsync();
        }
    }
}
