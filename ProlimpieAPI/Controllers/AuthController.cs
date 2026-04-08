using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProlimpieAPI.Models.SysAdmin;
using ProlimpieAPI.Models._DTO.Auth;

namespace ProlimpieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized(new
                {
                    success = false,
                    message = "Usuario no existe"
                });

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
                return Unauthorized(new
                {
                    sucess = false,
                    message = "Contraseña incorrecta"
                });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ESTA_ES_UNA_LLAVE_SUPER_SECRETA_12345"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claimsJWT = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claimsJWT.Add(new Claim(ClaimTypes.Role, role));

                var roleEntity = await _roleManager.FindByNameAsync(role);
                if (roleEntity != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(roleEntity);
                    foreach (var rc in roleClaims)
                    {
                        if (!claimsJWT.Any(c => c.Type == rc.Type && c.Value == rc.Value))
                        {
                            claimsJWT.Add(rc);
                        }
                    }
                }
            }
            
            var claims = await _userManager.GetClaimsAsync(user);
            foreach(var uc in claims)
            {
                if (!claimsJWT.Any(c => c.Type == uc.Type && c.Value == uc.Value))
                {
                    claimsJWT.Add(uc);
                }
            }

            var token = new JwtSecurityToken(
                //issuer: "API",
                //audience: "REACT",
                claims: claimsJWT,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                sucess = true,
                message = "login exitoso",
                token = tokenString,
            });
        }
    }
}
