namespace Cp2WebApplication.Domain.Entities
{
    public class Moto
    {
        private static readonly string[] StatusValidos = { "pronta", "revisao", "reservada", "fora de serviço", "sem placa" };

        public int Id { get; private set; }
        public string Placa { get; private set; } = string.Empty;
        public string? Posicao { get; private set; }
        public string Status { get; private set; } = "pronta";
        public DateTime UltimaAtualizacao { get; private set; } = DateTime.UtcNow;

        protected Moto() { }

        public Moto(string placa, string? posicao, string status)
        {
            AtualizarPlaca(placa);
            AtualizarPosicao(posicao);
            AtualizarStatus(status);
        }

        public void AtualizarPlaca(string novaPlaca)
        {
            if (string.IsNullOrWhiteSpace(novaPlaca))
                throw new ArgumentException("A placa não pode ser vazia.");
            if (novaPlaca.Length < 7 || novaPlaca.Length > 8)
                throw new ArgumentException("A placa deve ter entre 7 e 8 caracteres.");
            Placa = novaPlaca.Trim().ToUpper();
            AtualizarData();
        }

        public void AtualizarPosicao(string? novaPosicao)
        {
            if (string.IsNullOrWhiteSpace(novaPosicao))
                Posicao = null;
            else
                Posicao = novaPosicao.Trim().ToUpper();

            AtualizarData();
        }

        public void AtualizarStatus(string novoStatus)
        {
            if (!StatusValidos.Contains(novoStatus.ToLower()))
                throw new ArgumentException($"Status inválido: '{novoStatus}'. Valores permitidos: {string.Join(", ", StatusValidos)}");

            Status = novoStatus.ToLower();
            AtualizarData();
        }

        private void AtualizarData()
        {
            UltimaAtualizacao = DateTime.UtcNow;
        }
    }

}
