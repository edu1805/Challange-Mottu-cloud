using Cp2WebApplication.Domain.Entities;

namespace Cp2WebApplication.Infrastructure.Repositories
{
    public interface ILocalizacaoAtualRepository
    {
        Task<LocalizacaoAtual> ObterPorMotoIdAsync(int motoId);
        Task<IEnumerable<LocalizacaoAtual>> ListarTodasAsync();
        Task AdicionarAsync(LocalizacaoAtual localizacao);
        Task AtualizarAsync(LocalizacaoAtual localizacao);
        Task DeletarAsync(LocalizacaoAtual localizacao);

    }

}
