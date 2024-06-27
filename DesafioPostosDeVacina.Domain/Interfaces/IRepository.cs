namespace DesafioPostosDeVacina.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T newEntity);
        void Remove(T entity);
    }
}
