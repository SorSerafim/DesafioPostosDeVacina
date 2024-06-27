using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;
using DesafioPostosDeVacina.Infra.Context;

namespace Locadora.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        protected ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T newEntity)
        {
            _context.Set<T>().Update(newEntity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
