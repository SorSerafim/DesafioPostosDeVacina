namespace DesafioPostosDeVacina.Application.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int? id);
        Task Add(T dto);
        Task Update(T dto);
        Task Remove(int? id);
    }
}
