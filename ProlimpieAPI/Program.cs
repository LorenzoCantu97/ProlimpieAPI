using System.Text;
using ProlimpieAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var key = "ESTA_ES_UNA_LLAVE_SUPER_SECRETA_12345"; // MOVERLA A CONFIG

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
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
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

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

// CREAR ROLES
//using (var scope = app.Services.CreateScope())
//{
//    await IdentitySeeder.SeedRoles(scope.ServiceProvider);
//}

// CREAR USUARIO DE PRUEBA PARA LOGIN
//using (var scope = app.Services.CreateScope())
//{
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

//    var email = "correo@prueba.com";
//    var password = "Qwerty123!";

//    var user = await userManager.FindByEmailAsync(email);

//    if (user == null)
//    {
//        user = new IdentityUser
//        {
//            UserName = email,
//            Email = email
//        };

//        await userManager.CreateAsync(user, password);
//        await userManager.AddToRoleAsync(user, "Administrador");
//    }
//    else if (!await userManager.IsInRoleAsync(user, "Administrador"))
//    {
//        await userManager.AddToRoleAsync(user, "Administrador");
//    }

//}

app.Run();

// CREACION DE ROLES
//public static class IdentitySeeder
//{
//    public static async Task SeedRoles(IServiceProvider serviceProvider)
//    {
//        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//        string[] roles = { 
//            "Administrador", 
//            "Sistemas", 
//            "Supervisor de Ventas", 
//            "Auxiliar de Ventas", 
//            "Vendedor de Campo" 
//        };

//        foreach (var role in roles)
//        {
//            if (!await roleManager.RoleExistsAsync(role))
//                await roleManager.CreateAsync(new IdentityRole(role));
//        }
//    }
//}