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
        public async Task<Posto> CreateAsync(Posto entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Posto> UpdateAsync(Posto entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task RemoveAsync(Posto entity)
        {
            _context.Postos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Posto> GetByIdAsync(int? id)
        {
            return await _context.Postos.FindAsync(id);
        }

        public async Task<IEnumerable<Posto>> GetAllAsync()
        {
            return await _context.Postos.ToListAsync();
        }
    }
}
