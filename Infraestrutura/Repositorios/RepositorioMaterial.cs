using Domínio.Interfaces;
using Domínio.Model;
using Infraestrutura.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class RepositorioMaterial : IRepositorioMaterial
    {
        protected readonly Context _dbContext;
        protected readonly DbSet<Material> _dbSet;

        public RepositorioMaterial(Context dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Material>();
        }

        public async Task Adicionar(Material material)
        {
            await _dbSet.AddAsync(material);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Material material)
        {
            _dbSet.Update(material);
            await _dbContext.SaveChangesAsync();
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
            await _dbContext.SaveChangesAsync();
        }
    }
}
