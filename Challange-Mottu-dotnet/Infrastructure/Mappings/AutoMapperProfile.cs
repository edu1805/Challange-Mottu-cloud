using AutoMapper;
using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.DTOs;

namespace Cp2WebApplication.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Moto, MotoDto>().ReverseMap();

            CreateMap<LocalizacaoAtual, LocalizacaoAtualDto>().ReverseMap();
            CreateMap<CriarLocalizacaoAtualDto, LocalizacaoAtual>();
        }
    }
}
