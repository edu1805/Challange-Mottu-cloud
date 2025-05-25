namespace Cp2WebApplication.Infrastructure.DTOs
{
    /// <summary>
    /// DTO para criação de uma nova moto.
    /// </summary>
    public class CreateMotoDto
    {
        /// <summary>
        /// Placa da moto.
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        /// Posição da moto no pátio.
        /// </summary>
        public string Posicao { get; set; }

        /// <summary>
        /// Status atual da moto (ex: disponível, manutenção).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Data e hora da última atualização da moto.
        /// </summary>
        public DateTime? UltimaAtualizacao { get; set; }
    }

}
