using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;
using DesafioPostosDeVacina.Infra.Context;
using Locadora.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioPostosDeVacina.Infra.Repositories
{
    public class VacinaRepository : RepositoryBase<Vacina>, IVacinaRepository
    {
        private ApplicationDbContext _context;

        public VacinaRepository(ApplicationDbContext context) : base(context)
        {     
        }

        /*
        public override Vacina GetById(int id)
        {
            return _context.Vacinas
                .Include(v => v.Posto)
                .FirstOrDefault(x => x.Id == id);
        }

        public override List<Vacina> GetAll()
        {
            return _context.Vacinas
                .Include(v => v.Posto)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public List<Vacina> GetAllWithNameOfPosto(string nome)
        {
            return _context.Vacinas
                .Include(v => v.Posto)
                .Where(x => x.Posto.Nome.Equals(nome))
                .ToList();
        }
        */
    }
}
