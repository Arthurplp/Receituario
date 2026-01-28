using Domínio.Interfaces;
using Domínio.Model;
using Infraestrutura.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class RepositorioMaterial : IRepositorioMaterial
    {
        protected readonly Context _context;
        protected readonly DbSet<Material> _dbSet;

        public RepositorioMaterial(Context context)
        {
            _context = context;
            _dbSet = _context.Set<Material>();
        }

        public async Task Adicionar(Material material)
        {
            await _dbSet.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Material material)
        {
            _dbSet.Update(material);
            await _context.SaveChangesAsync();
        }

        public async Task<Material?> ObterPorId(Guid id)
        {
            var material = await _dbSet.FindAsync(id);
            return material;
        }

        public async Task<List<Material>> ObterTodos()
        {
            var listamaterial = await _dbSet.ToListAsync();
            return listamaterial;
        }

        public async Task Remover(Guid id)
        {
            var material = await ObterPorId(id);

            _dbSet.Remove(material!);
            await _context.SaveChangesAsync();
        }
    }
}
