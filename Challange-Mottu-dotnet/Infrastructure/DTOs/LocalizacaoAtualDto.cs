namespace Cp2WebApplication.Infrastructure.DTOs
{
    /// <summary>
    /// DTO para exibir a localização atual de uma moto.
    /// </summary>
    public class LocalizacaoAtualDto
    {
        /// <summary>
        /// Identificador da localização.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID da moto associada.
        /// </summary>
        public int MotoId { get; set; }

        /// <summary>
        /// Coordenada X da moto no pátio.
        /// </summary>
        public double CoordenadaX { get; set; }

        /// <summary>
        /// Coordenada Y da moto no pátio.
        /// </summary>
        public double CoordenadaY { get; set; }

        /// <summary>
        /// Data e hora da última atualização de localização.
        /// </summary>
        public DateTime DataHoraAtualizacao { get; set; }
    }

    /// <summary>
    /// DTO para criação de uma nova localização atual.
    /// </summary>
    public class CriarLocalizacaoAtualDto
    {
        /// <summary>
        /// ID da moto.
        /// </summary>
        public int MotoId { get; set; }

        /// <summary>
        /// Coordenada X.
        /// </summary>
        public double CoordenadaX { get; set; }

        /// <summary>
        /// Coordenada Y.
        /// </summary>
        public double CoordenadaY { get; set; }
    }

    /// <summary>
    /// DTO para atualizar coordenadas de uma localização atual.
    /// </summary>
    public class AtualizarLocalizacaoAtualDto
    {
        /// <summary>
        /// Nova coordenada X.
        /// </summary>
        public double CoordenadaX { get; set; }

        /// <summary>
        /// Nova coordenada Y.
        /// </summary>
        public double CoordenadaY { get; set; }
    }

}
