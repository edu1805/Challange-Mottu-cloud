namespace Cp2WebApplication.Infrastructure.DTOs
{
    /// <summary>
    /// DTO para atualização dos dados de uma moto.
    /// </summary>
    public class UpdateMotoDto
    {
        /// <summary>
        /// Nova posição da moto no pátio.
        /// </summary>
        public string Posicao { get; set; }

        /// <summary>
        /// Novo status da moto.
        /// </summary>
        public string Status { get; set; }
    }

}
