using Domínio.Model;
using Domínio.Interfaces;
using Infraestrutura.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    internal class RepositorioVinculo : IRepositorioVinculo
    {
        private readonly Context _dbContext;
        private readonly DbSet<VinculoReceitaMaterial> _dbSet;

        public RepositorioVinculo(Context dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<VinculoReceitaMaterial>();
        }

        public async Task Adicionar(VinculoReceitaMaterial vinculo)
        {
            await _dbSet.AddAsync(vinculo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(VinculoReceitaMaterial vinculo)
        {
            _dbSet.Update(vinculo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<VinculoReceitaMaterial?> ObterPorId(Guid id)
        {
            var vinculo = await _dbSet.FindAsync(id);
            return vinculo;
        }

        public async Task<List<VinculoReceitaMaterial>> ObterTodos()
        {
            var vinculo = await _dbSet.ToListAsync();
            return vinculo;
        }

        public async Task Remover(Guid id)
        {
            var vinculoId = await ObterPorId(id);
            _dbSet.Remove(vinculoId!);
            await _dbContext.SaveChangesAsync();
        }
    }
}
