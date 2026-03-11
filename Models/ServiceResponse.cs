namespace WebApi_video.Models
{
    /// <summary>
    /// Classe genérica para padronizar as respostas de serviço da API.
    /// </summary>
    /// <typeparam name="T">Tipo de dado contido na resposta.</typeparam>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Dados retornados pela operação.
        /// </summary>
        public T? Dados { get; set; }
        
        /// <summary>
        /// Mensagem descritiva da operação, útil para feedback ao cliente.
        /// </summary>
        public string Mensagem { get; set; } = string.Empty;

        /// <summary>
        /// Indica se a operação foi executada com sucesso.
        /// </summary>
        public bool Sucesso { get; set; } = true;
    }
}
