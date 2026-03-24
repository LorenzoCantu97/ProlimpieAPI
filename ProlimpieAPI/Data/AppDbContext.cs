using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProlimpieAPI.Models;

namespace ProlimpieAPI.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Empresa> Empresas { get; set; }
    }
}
