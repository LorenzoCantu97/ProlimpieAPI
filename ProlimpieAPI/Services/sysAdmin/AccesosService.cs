using Microsoft.EntityFrameworkCore;
using ProlimpieAPI.Data;
using ProlimpieAPI.Models._DTO.SysAdmin;

namespace ProlimpieAPI.Services.sysAdmin
{
    public interface IAccesosService
    {
        Task<List<AccesosDTO>> GetAccesosGrid();
    }

    public class AccesosService : IAccesosService
    {
        private readonly AppDbContext _appDbContext;
        public AccesosService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<AccesosDTO>> GetAccesosGrid()
        {
            return await (
                from claim in _appDbContext.UserClaims

                join created in _appDbContext.Users
                    on claim.CreatedById equals created.Id into createdGroup
                from createdUser in createdGroup.DefaultIfEmpty()

                join updated in _appDbContext.Users
                    on claim.UpdatedById equals updated.Id into updatedGroup
                from updatedUser in updatedGroup.DefaultIfEmpty()

                where claim.ClaimType == "Acceso"

                select new AccesosDTO
                {
                    Id = claim.Id,
                    Tipo = claim.ClaimType,
                    Modulo = claim.ModulosId != null
                        ? _appDbContext.Modulos
                            .Where(m => m.Id == claim.ModulosId)
                            .Select(m => m.Nombre)
                            .FirstOrDefault()
                        : null,
                    Nombre = claim.ClaimValue,
                    CreatedBy = createdUser != null ? createdUser.Nombre : null,
                    CreatedAt = claim.CreatedAt,
                    UpdatedBy = updatedUser != null ? updatedUser.Nombre : null,
                    UpdatedAt = claim.UpdatedAt
                }
            ).ToListAsync();
        }
    }
}
