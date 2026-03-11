using System.ComponentModel.DataAnnotations;
using WebApi_video.Enums;

namespace WebApi_video.Models
{
    /// <summary>
    /// Modelo de dados (DTO) para funcionário.
    /// </summary>
    public class FuncionarioModels
    {
        /// <summary>
        /// Identificador único do funcionário.
        /// </summary>
        [Key] 
        public int Id { get; set; }

        /// <summary>
        /// Nome do funcionário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do funcionário.
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Departamento ao qual o funcionário pertence.
        /// </summary>
        public DepartamentoEnum Departamento { get; set; }

        /// <summary>
        /// Indica se o funcionário está ativo.
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Turno de trabalho do funcionário.
        /// </summary>
        public TurnoEnum Turno { get; set; }

        /// <summary>
        /// Data e hora da criação do registro do funcionário.
        /// </summary>
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();

        /// <summary>
        /// Data e hora da última alteração do registro do funcionário.
        /// </summary>
        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
