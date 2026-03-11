using Microsoft.EntityFrameworkCore;
using WebApi_video.Models;

namespace WebApi_video.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<FuncionarioModels> Funcionarios { get; set; }
    }
}
