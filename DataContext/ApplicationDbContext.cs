using Microsoft.EntityFrameworkCore;
using WebApi_video.Models;

namespace WebApi_video.DataContext
{
    /// <summary>
    /// Contexto do banco de dados da aplicação. Gerencia a conexão com o SQL Server
    /// e expõe os DbSets utilizados pelo Entity Framework Core.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Inicializa o contexto com as opções de configuração fornecidas pela injeção de dependência.
        /// </summary>
        /// <param name="options">Opções de configuração do DbContext, incluindo a connection string.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        /// <summary>
        /// Representa a tabela de funcionários no banco de dados.
        /// </summary>
        public DbSet<FuncionarioModels> Funcionarios { get; set; }
    }
}
