using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;
using DesafioPostosDeVacina.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioPostosDeVacina.Infra.Repositories
{
    public class PostoRepository : IRepository<Posto>
    {
        private ApplicationDbContext _context;

        public PostoRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public void Create(Posto entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Posto entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Posto entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public Posto GetById(int id)
        {
            return _context.Postos.FirstOrDefault(p => p.Id == id);
        }

        public List<Posto> GetAll()
        {
            return _context.Postos.ToList();
        }
    }
}
