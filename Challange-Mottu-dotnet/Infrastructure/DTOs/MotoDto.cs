namespace Cp2WebApplication.Infrastructure.DTOs
{
    /// <summary>
    /// DTO para exibição de dados de uma moto.
    /// </summary>
    public class MotoDto
    {
        /// <summary>
        /// Identificador da moto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Placa da moto.
        /// </summary>
        public string Placa { get; set; } = string.Empty;

        /// <summary>
        /// Status atual da moto.
        /// </summary>
        public string Status { get; set; } = "desconhecido";

        /// <summary>
        /// Data e hora da última atualização da moto.
        /// </summary>
        public DateTime? UltimaAtualizacao { get; set; }
    }

}
