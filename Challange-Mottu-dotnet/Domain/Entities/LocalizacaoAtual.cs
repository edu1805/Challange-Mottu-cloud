namespace Cp2WebApplication.Domain.Entities
{
    public class LocalizacaoAtual
    {
        public int Id { get; private set; }
        public int MotoId { get; private set; }
        public Moto Moto { get; private set; }
        public double CoordenadaX { get; private set; }
        public double CoordenadaY { get; private set; }

        public DateTime DataHoraAtualizacao { get; private set; }

        private LocalizacaoAtual() { }

        public LocalizacaoAtual(int motoId, double coordenadaX, double coordenadaY)
        {
            Validar(motoId, coordenadaX, coordenadaY);

            MotoId = motoId;
            CoordenadaX = coordenadaX;
            CoordenadaY = coordenadaY;
            DataHoraAtualizacao = DateTime.UtcNow;
        }

        public void AtualizarCoordenadas(double coordenadaX, double coordenadaY)
        {
            Validar(MotoId, coordenadaX, coordenadaY);

            CoordenadaX = coordenadaX;
            CoordenadaY = coordenadaY;
            DataHoraAtualizacao = DateTime.UtcNow;
        }

        private void Validar(int motoId, double coordenadaX, double coordenadaY)
        {
            if (motoId <= 0)
                throw new ArgumentException("MotoId inválido.");

            if (coordenadaX < 0 || coordenadaY < 0)
                throw new ArgumentException("Coordenadas não podem ser negativas.");

            if (coordenadaX > 1000 || coordenadaY > 1000)
                throw new ArgumentException("Coordenadas fora do limite permitido.");
        }
    }


}
