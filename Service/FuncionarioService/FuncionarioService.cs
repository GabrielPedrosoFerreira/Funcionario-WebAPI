using Microsoft.EntityFrameworkCore;
using WebApi_video.DataContext;
using WebApi_video.Models;

namespace WebApi_video.Service.FuncionarioService
{
    /// <summary>
    /// Implementa as operações de negócio para gerenciamento de funcionários,
    /// acessando o banco de dados via <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa o serviço com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Instância do <see cref="ApplicationDbContext"/>.</param>
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<List<FuncionarioModels>>> CreateFuncionario(FuncionarioModels novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                if (novoFuncionario is null)
                {
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;
                    serviceResponse.Dados = null;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message.ToString();
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<List<FuncionarioModels>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                FuncionarioModels funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

                if (funcionario is null)
                {
                    serviceResponse.Mensagem = "Funcionario não localizado";
                    serviceResponse.Sucesso = false;
                    serviceResponse.Dados = null;

                    return serviceResponse;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message.ToString();
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<FuncionarioModels>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModels> serviceResponse = new ServiceResponse<FuncionarioModels>();

            try
            {
                FuncionarioModels funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

                if (funcionario is null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.Dados = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message.ToString();
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<List<FuncionarioModels>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum funcionário encontrado.";
                }
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message.ToString();
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<List<FuncionarioModels>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                FuncionarioModels funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

                if (funcionario is null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message.ToString();
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<List<FuncionarioModels>>> UpdateFuncionario(FuncionarioModels editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                FuncionarioModels funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(f => f.Id == editadoFuncionario.Id);

                if (funcionario is null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    serviceResponse.Sucesso = false;
                }

                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message.ToString();
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
