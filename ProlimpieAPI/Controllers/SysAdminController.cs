using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProlimpieAPI.Services;

namespace ProlimpieAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SysAdminController : ControllerBase
    {
        private readonly IUsuariosService _usuarioService;

        public SysAdminController(IUsuariosService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("usuariosGrid")]
        [Authorize]
        public async Task<IActionResult> GetUsuariosGrid()
        {
            var usuarios = await _usuarioService.GetUsuariosGrid();
            return Ok(usuarios);
        }

    }
}
