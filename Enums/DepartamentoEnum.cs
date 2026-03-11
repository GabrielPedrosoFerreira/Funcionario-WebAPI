using System.ComponentModel;

namespace WebApi_video.Enums
{
    /// <summary>
    /// Enumeração dos departamentos disponíveis na organização.
    /// </summary>
    public enum DepartamentoEnum
    {
        /// <summary>
        /// Departamento de Recursos Humanos responsável pela gestão de pessoal.
        /// </summary>
        [Description("Recursos Humanos")]
        Rh = 1,
        
        /// <summary>
        /// Departamento Financeiro responsável pela gestão financeira.
        /// </summary>
        [Description("Financeiro")]
        Financeiro = 2,
        
        /// <summary>
        /// Departamento de Compras responsável pelas aquisições.
        /// </summary>
        [Description("Compras")]
        Compras = 3,
        
        /// <summary>
        /// Departamento de Atendimento responsável pelo relacionamento com clientes.
        /// </summary>
        [Description("Atendimento")]
        Atendimento = 4,
        
        /// <summary>
        /// Departamento de Zeladoria responsável pela limpeza e manutenção.
        /// </summary>
        [Description("Zeladoria")]
        Zeladoria = 5,
    }
}
