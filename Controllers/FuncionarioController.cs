using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_video.Models;
using WebApi_video.Service.FuncionarioService;

namespace WebApi_video.Controllers
{
    /// <summary>
    /// Controller responsável por expor os endpoints HTTP para gerenciamento de funcionários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;

        /// <summary>
        /// Inicializa o controller com a injeção da interface de serviço de funcionários.
        /// </summary>
        /// <param name="funcionarioInterface">Instância do serviço de funcionários.</param>
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
                _funcionarioInterface = funcionarioInterface;
        }

        /// <summary>
        /// Retorna a lista de todos os funcionários cadastrados.
        /// </summary>
        /// <returns>Lista de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> GetFuncionarios()
        {
            var retorno = await _funcionarioInterface.GetFuncionarios();
            if (retorno is null)
                return BadRequest();
            else
                return Ok(retorno);
        }

        /// <summary>
        /// Retorna um funcionário pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do funcionário.</param>
        /// <returns>Funcionário encontrado ou mensagem de erro encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModels>>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModels> retorno = await _funcionarioInterface.GetFuncionarioById(id);
            if (retorno is null)
                return BadRequest();
            else
                return Ok(retorno);
        }

        /// <summary>
        /// Cadastra um novo funcionário.
        /// </summary>
        /// <param name="novoFuncionario">Dados do funcionário a ser criado.</param>
        /// <returns>Lista atualizada de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> CreateFuncionario(FuncionarioModels novoFuncionario)
        {
            var retorno = await _funcionarioInterface.CreateFuncionario(novoFuncionario);
            if (retorno is null)
                return BadRequest();
            else
                return Ok(retorno);
        }

        /// <summary>
        /// Atualiza os dados de um funcionário existente.
        /// </summary>
        /// <param name="editadoFuncionario">Dados atualizados do funcionário.</param>
        /// <returns>Lista atualizada de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> UpdateFuncionario(FuncionarioModels editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModels>> retorno = await _funcionarioInterface.UpdateFuncionario(editadoFuncionario);

            if (retorno is null)
                return BadRequest();
            else
                return Ok(retorno);
        }

        /// <summary>
        /// Inativa um funcionário pelo seu identificador, definindo o campo <c>Ativo</c> como <c>false</c>.
        /// </summary>
        /// <param name="id">Identificador único do funcionário a ser inativado.</param>
        /// <returns>Lista atualizada de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModels>> retorno = await _funcionarioInterface.InativaFuncionario(id);

            if (retorno is null)
                return BadRequest();
            else
                return Ok(retorno);
        }

        /// <summary>
        /// Remove um funcionário pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do funcionário a ser removido.</param>
        /// <returns>Lista atualizada de funcionários encapsulada em <see cref="ServiceResponse{T}"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModels>> retorno = await _funcionarioInterface.DeleteFuncionario(id);

            if (retorno is null)
                return BadRequest();
            else
                return Ok(retorno);
        }

    }
}
