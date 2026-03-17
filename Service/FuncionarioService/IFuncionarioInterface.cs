using WebApi_video.Models;

namespace WebApi_video.Service.FuncionarioService
{
    /// <summary>
    /// Define o contrato das operações de negócio para gerenciamento de funcionários.
    /// </summary>
    public interface IFuncionarioInterface
    {
        /// <summary>
        /// Retorna a lista de todos os funcionários cadastrados.
        /// </summary>
        /// <returns>Lista de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        Task<ServiceResponse<List<FuncionarioModels>>> GetFuncionarios();

        /// <summary>
        /// Cadastra um novo funcionário.
        /// </summary>
        /// <param name="novoFuncionario">Dados do funcionário a ser criado.</param>
        /// <returns>Lista atualizada de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        Task<ServiceResponse<List<FuncionarioModels>>> CreateFuncionario(FuncionarioModels novoFuncionario);

        /// <summary>
        /// Retorna um funcionário pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do funcionário.</param>
        /// <returns>Funcionário encontrado encapsulado em <see cref="ServiceResponse{T}"/>.</returns>
        Task<ServiceResponse<FuncionarioModels>> GetFuncionarioById(int id);

        /// <summary>
        /// Atualiza os dados de um funcionário existente.
        /// </summary>
        /// <param name="editadoFuncionario">Dados atualizados do funcionário.</param>
        /// <returns>Lista atualizada de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        Task<ServiceResponse<List<FuncionarioModels>>> UpdateFuncionario(FuncionarioModels editadoFuncionario);

        /// <summary>
        /// Remove um funcionário pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do funcionário a ser removido.</param>
        /// <returns>Lista atualizada de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        Task<ServiceResponse<List<FuncionarioModels>>> DeleteFuncionario(int id);

        /// <summary>
        /// Inativa um funcionário pelo seu identificador, definindo o campo <c>Ativo</c> como <c>false</c>.
        /// </summary>
        /// <param name="id">Identificador único do funcionário a ser inativado.</param>
        /// <returns>Lista atualizada de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        Task<ServiceResponse<List<FuncionarioModels>>> InativaFuncionario(int id);
    }
}
