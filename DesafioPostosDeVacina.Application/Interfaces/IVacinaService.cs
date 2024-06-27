using DesafioPostosDeVacina.Application.DTOs;
using FluentResults;

namespace DesafioPostosDeVacina.Application.Interfaces
{
    public interface IVacinaService
    {
        void CreateVacina(CreateVacinaDTO createDto);
        Result UpdateVacina(int id, CreateVacinaDTO updateDto);
        Result DeleteVacina(int id);
        ReadVacinaDTO GetVacina(int id);
        List<ReadVacinaDTO> GetAllVacinas();
        /*
        List<ReadVacinaDTO> GetAllVacinasOfOnePosto(string nome);
        */
    }
}
