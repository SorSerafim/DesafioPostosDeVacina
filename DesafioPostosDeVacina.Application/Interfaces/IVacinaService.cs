namespace DesafioPostosDeVacina.Application.Interfaces
{
    public interface IVacinaService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(int id, T dto);
        Task Update(T dto);
        Task Remove(int id);
    }
}
