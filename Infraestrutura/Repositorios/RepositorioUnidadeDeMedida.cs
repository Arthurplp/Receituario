using Domínio.Interfaces;
using Domínio.Model;
using Infraestrutura.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class RepositorioUnidadeDeMedida : IRepositorioUnidadeDeMedida
    {
        protected readonly Context _context;
        protected readonly DbSet<UnidadeDeMedida> _dbSet;

        public RepositorioUnidadeDeMedida(Context context)
        {
            _context = context;
            _dbSet = _context.Set<UnidadeDeMedida>();
        }

        public async Task Adicionar(UnidadeDeMedida unidadeDeMedida)
        {
            await _dbSet.AddAsync(unidadeDeMedida);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(UnidadeDeMedida unidadeDeMedida)
        {
            _dbSet.Update(unidadeDeMedida);
            await _context.SaveChangesAsync();
        }

        public async Task<UnidadeDeMedida?> ObterPorId(Guid id)
        {
            var unidadeDeMedida = await _dbSet.FindAsync(id);
            return unidadeDeMedida;
        }

        public async Task<List<UnidadeDeMedida>> ObterTodos()
        {
            var unidadeDeMedida = await _dbSet.ToListAsync();
            return unidadeDeMedida;
        }

        public async Task Remover(Guid id)
        {
            var unidadeDeMedida = await ObterPorId(id);

            _dbSet.Remove(unidadeDeMedida!);
            await _context.SaveChangesAsync();
        }



    }
}
