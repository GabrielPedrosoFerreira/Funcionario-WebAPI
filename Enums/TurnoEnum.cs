using System.ComponentModel;

namespace WebApi_video.Enums
{
    /// <summary>
    /// Enumeração dos turnos de trabalho disponíveis.
    /// </summary>
    public enum TurnoEnum
    {
        /// <summary>
        /// Turno matutino das 6h às 14h.
        /// </summary>
        [Description("Manhã")]
        Manha = 1,
        
        /// <summary>
        /// Turno vespertino das 14h às 22h.
        /// </summary>
        [Description("Tarde")]
        Tarde = 2,
        
        /// <summary>
        /// Turno noturno das 22h às 6h.
        /// </summary>
        [Description("Noite")]
        Noite = 3
    }
}
