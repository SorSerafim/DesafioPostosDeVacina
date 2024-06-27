using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;
using DesafioPostosDeVacina.Infra.Context;
using Locadora.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioPostosDeVacina.Infra.Repositories
{
    public class PostoRepository : RepositoryBase<Posto>, IPostoRepository
    {
        public PostoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override List<Posto> GetAll()
        {
            return _context.Postos
                .Include(p => p.Vacinas)
                .OrderBy(p => p.Nome)
                .ToList();
        }
    }
}
