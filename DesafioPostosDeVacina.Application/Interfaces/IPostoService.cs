using DesafioPostosDeVacina.Application.DTOs;
using FluentResults;

namespace DesafioPostosDeVacina.Application.Interfaces
{
    public interface IPostoService
    {
        void CreatePosto(CreatePostoDTO createDto);
        Result UpdatePosto(int id, CreatePostoDTO updateDto);
        Result DeletePosto(int id);
        ReadPostoDTO GetPosto(int id);
        List<ReadPostoDTO> GetAllPostos();
    }
}
