using DesafioPostosDeVacina.Domain.Entities;

namespace DesafioPostosDeVacina.Domain.Interfaces
{
    public interface IVacinaRepository : IRepository<Vacina>
    {
        //List<Vacina> GetAllWithNameOfPosto(string posto);
    }
}
