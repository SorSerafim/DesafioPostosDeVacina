using AutoMapper;
using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Domain.Entities;

namespace DesafioPostosDeVacina.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Posto, ReadPostoDTO>();
            CreateMap<CreatePostoDTO, Posto>();

            CreateMap<CreateVacinaDTO, Vacina>();
            CreateMap<Vacina, ReadVacinaDTO>()
                .ForMember(dest => dest.Posto, opt => opt
                .MapFrom(src => src.Nome));
        }
    }
}
