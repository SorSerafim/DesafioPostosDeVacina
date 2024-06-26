using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;
using DesafioPostosDeVacina.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioPostosDeVacina.Infra.Repositories
{
    public class VacinaRepository : IRepository<Vacina>
    {
        private ApplicationDbContext _context;

        public VacinaRepository(ApplicationDbContext context) 
        {
            _context = context;        
        }
        public void Create(Vacina entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Vacina entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Vacina entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public Vacina GetById(int id)
        {
            return _context.Vacinas.FirstOrDefault(p => p.Id == id);
        }

        public List<Vacina> GetAll()
        {
            return _context.Vacinas.ToList();
        }
    }
}
