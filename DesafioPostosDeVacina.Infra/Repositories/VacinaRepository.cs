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
        public async Task<Vacina> CreateAsync(Vacina entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Vacina>> GetAllAsync()
        {
            return await _context.Vacinas.ToListAsync();
        }

        public async Task<Vacina> GetByIdAsync(int? id)
        {
            return await _context.Vacinas.FindAsync(id);
        }

        public async Task<Vacina> RemoveAsync(Vacina entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Vacina> UpdateAsync(Vacina entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
