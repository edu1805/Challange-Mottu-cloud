using AutoMapper;
using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.DTOs;

namespace Cp2WebApplication.Infrastructure.Mappings
{
    public class LocalizacaoAtualProfile : Profile
    {
        public LocalizacaoAtualProfile()
        {
            CreateMap<LocalizacaoAtual, LocalizacaoAtualDto>();
            CreateMap<CriarLocalizacaoAtualDto, LocalizacaoAtual>();
            CreateMap<AtualizarLocalizacaoAtualDto, LocalizacaoAtual>();
        }
    }

}
