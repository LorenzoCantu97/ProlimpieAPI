using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProlimpieAPI.Data;
using ProlimpieAPI.Interfaces;
using ProlimpieAPI.Models.SysAdmin;
using ProlimpieAPI.Services;
using System.Security.Claims;
using System.Text;

var key = "ESTA_ES_UNA_LLAVE_SUPER_SECRETA_12345"; // MOVERLA A CONFIG

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        // AL PASAR A PRODUCCIÓN CAMBIAR EL ORIGIN AL DOMINIO DE REACT
        policy.WithOrigins("http://localhost:56004")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        //ValidIssuer = "API",
        ValidateAudience = false,
        //ValidAudience = "REACT",
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key)
        )
    };
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("ReactPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// CREAR USUARIOS DE PRUEBA PARA PRUEBAS
//using (var scope = app.Services.CreateScope())
//{
//    await IdentitySeeder.DeleteAndCreateRolesAndUsers(scope.ServiceProvider);
//}

app.Run();

public static class IdentitySeeder
{
    public static string[] rolesArr = 
    {
        "Administrador",
        //"Sistemas",
        //"Supervisor de Ventas",
        //"Auxiliar de Ventas",
        //"Vendedor de Campo"
    };

    public static List<ApplicationUser> userList = new List<ApplicationUser>()
    {
        new ApplicationUser { 
            UserName = "admin",     
            Email = "admin@prueba.com",     
            EmailConfirmed = true,
            Nombre = "Admin",
            ApellidoPaterno = string.Empty,
            ApellidoMaterno = string.Empty,
            FechaNacimiento = DateTime.Now,
            FechaIngreso = DateTime.Now,
            SucursalesEmpresasId = 0,
            EntidadesId = 0,
            Activo = true,
            CreatedById = string.Empty,
            CreatedAt = DateTime.Now,
            UpdatedById = string.Empty,
            UpdatedAt = DateTime.Now,
        },
        //new IdentityUser { UserName = "sistemas",  Email = "sistemas@prueba.com",  EmailConfirmed = true },
        //new IdentityUser { UserName = "supVentas", Email = "supVentas@prueba.com", EmailConfirmed = true },
        //new IdentityUser { UserName = "auxVentas", Email = "auxVentas@prueba.com", EmailConfirmed = true },
        //new IdentityUser { UserName = "venVentas", Email = "venVentas@prueba.com", EmailConfirmed = true },
    };

    /*
        CREACION DE ROLES Y CREACION DE USUARIOS
        SOLO AMBIENTE DE PRUEBAS/DESARROLLO
        PARA PROBAR USUARIOS Y ROLES EN LA APLICACION
     */
    public static async Task DeleteAndCreateRolesAndUsers(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService <UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // ELIMINAR USUARIOS
        var users = userManager.Users.ToList();
        foreach(var user in users)
        {
            await userManager.DeleteAsync(user);
        }

        // ELIMINAR ROLES
        var roles = roleManager.Roles.ToList();
        foreach(var role in roles)
        {
            await roleManager.DeleteAsync(role);
        }

        // CREAR ROLES
        foreach(var rol in rolesArr)
        {
            if (!await roleManager.RoleExistsAsync(rol))
                await roleManager.CreateAsync(new IdentityRole(rol));
        }

        // CREAR USUARIOS Y APLICAR ROLES
        foreach(var user in userList)
        {
            var userExist = await userManager.FindByEmailAsync(user.Email ?? "");
            if (userExist == null)
            {
                var result = await userManager.CreateAsync(user, "Qwerty123@");

                if (result.Succeeded)
                {
                    switch (user.UserName)
                    {
                        case "admin":
                            await userManager.AddToRoleAsync(user, "Administrador");
                            // PERMISOS PARA ADMIN
                            var claims = new List<Claim>
                            {
                                new Claim("Permiso", "Usuarios.Crear"),
                                new Claim("Permiso", "Usuarios.Borrar"),
                                new Claim("Permiso", "Usuarios.Editar"),
                                new Claim("Permiso", "Roles.Crear"),
                                new Claim("Permiso", "Roles.Borrar"),
                                new Claim("Permiso", "Roles.Editar"),
                                new Claim("Permiso", "Accesos.Crear"),
                                new Claim("Permiso", "Accesos.Borrar"),
                                new Claim("Permiso", "Accesos.Editar"),
                                new Claim("Permiso", "Permisos.Crear"),
                                new Claim("Permiso", "Permisos.Borrar"),
                                new Claim("Permiso", "Permisos.Editar"),
                                new Claim("Acceso", "SysAdmin"),
                                new Claim("Acceso", "SysAdmin.Usuarios"),
                                new Claim("Acceso", "SysAdmin.Roles"),
                                new Claim("Acceso", "SysAdmin.Accesos"),
                                new Claim("Acceso", "SysAdmin.Permisos"),
                                new Claim("Acceso", "SysAdmin.Historial")
                            };
                            foreach (var claim in claims)
                            {
                                if (!(await userManager.GetClaimsAsync(user)).Any(c => c.Type == claim.Type && c.Value == claim.Value))
                                {
                                    await userManager.AddClaimAsync(user, claim);
                                }
                            }
                            break;
                        case "sistemas":
                            await userManager.AddToRoleAsync(user, "Sistemas");
                            break;
                        case "supVentas":
                            await userManager.AddToRoleAsync(user, "Supervisor de Ventas");
                            break;
                        case "auxVentas":
                            await userManager.AddToRoleAsync(user, "Auxiliar de Ventas");
                            break;
                        case "venVentas":
                            await userManager.AddToRoleAsync(user, "Vendedor de Campo");
                            break;
                    }
                }
            }
        }
    }

    // CREAR ROLES
    public static async Task SeedRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (var role in rolesArr)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // CREAR USUARIO DE PRUEBA
    public static async Task SeedUsers(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var email = "correo@prueba.com";
        var password = "Qwerty123!";

        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            user = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, "Administrador");
        }
        else if (!await userManager.IsInRoleAsync(user, "Administrador"))
        {
            await userManager.AddToRoleAsync(user, "Administrador");
        }
    }


}