using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProlimpieAPI.Services.sysAdmin;

namespace ProlimpieAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SysAdminController : ControllerBase
    {
        private readonly IUsuariosService _usuarioService;
        private readonly IRolesService _rolesService;
        private readonly IAccesosService _accesosService;
        private readonly IPermisosService _permisosService;
        private readonly IHistorialService _historialService;

        public SysAdminController(
            IUsuariosService usuarioService,
            IRolesService rolesService,
            IAccesosService accesosService,
            IPermisosService permisosService,
            IHistorialService historialService
        )
        {
            _usuarioService = usuarioService;
            _rolesService = rolesService;
            _accesosService = accesosService;
            _permisosService = permisosService;
            _historialService = historialService;
        }

        [HttpGet("usuariosGrid")]
        [Authorize]
        public async Task<IActionResult> GetUsuariosGrid()
        {
            var data = await _usuarioService.GetUsuariosGrid();
            return Ok(data);
        }

        [HttpGet("rolesGrid")]
        [Authorize]
        public async Task<IActionResult> GetRolesGrid()
        {
            var data = await _rolesService.GetRolesGrid();
            return Ok(data);
        }

        [HttpGet("accesosGrid")]
        [Authorize]
        public async Task<IActionResult> GetAccesosGrid()
        {
            var data = await _accesosService.GetAccesosGrid();
            return Ok(data);
        }

        [HttpGet("permisosGrid")]
        [Authorize]
        public async Task<IActionResult> GetPermisosGrid()
        {
            var data = await _permisosService.GetPermisosGrid();
            return Ok(data);
        }

        [HttpGet("historialGrid")]
        [Authorize]
        public async Task<IActionResult> GetHistorialGrid()
        {
            var data = await _historialService.GetHistorialGrid();
            return Ok(data);
        }
    }
}
