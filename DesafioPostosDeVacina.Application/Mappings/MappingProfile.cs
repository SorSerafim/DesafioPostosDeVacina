using AutoMapper;
using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Domain.Entities;

namespace DesafioPostosDeVacina.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Posto, PostoDTO>().ReverseMap();
            CreateMap<CreatePostoDTO, Posto>();
            CreateMap<Vacina, VacinaDTO>().ReverseMap();
            CreateMap<CreateVacinaDTO, Vacina>();
        }
    }
}
