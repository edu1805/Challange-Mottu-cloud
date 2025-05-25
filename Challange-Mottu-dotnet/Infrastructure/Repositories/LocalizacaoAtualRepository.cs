using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cp2WebApplication.Infrastructure.Repositories
{
    public class LocalizacaoAtualRepository : ILocalizacaoAtualRepository
    {
        private readonly Cp2Context _context;

        public LocalizacaoAtualRepository(Cp2Context context)
        {
            _context = context;
        }

        public async Task<LocalizacaoAtual> ObterPorMotoIdAsync(int motoId)
        {
            return await _context.LocalizacoesAtuais
                .FirstOrDefaultAsync(l => l.MotoId == motoId);
        }

        public async Task<IEnumerable<LocalizacaoAtual>> ListarTodasAsync()
        {
            return await _context.LocalizacoesAtuais.ToListAsync();
        }

        public async Task AdicionarAsync(LocalizacaoAtual localizacao)
        {
            await _context.LocalizacoesAtuais.AddAsync(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(LocalizacaoAtual localizacao)
        {
            _context.LocalizacoesAtuais.Update(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(LocalizacaoAtual localizacao)
        {
            _context.LocalizacoesAtuais.Remove(localizacao);
            await _context.SaveChangesAsync();
        }

    }

}
