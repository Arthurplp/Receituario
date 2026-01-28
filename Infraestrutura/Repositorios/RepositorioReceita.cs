using Domínio.Model;
using Domínio.Interfaces;
using Infraestrutura.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class RepositorioReceita : IRepositorioReceita
    {
        protected readonly Context _context;
        protected readonly DbSet<Receita> _dbSet;

        public RepositorioReceita(Context context)
        {
            _context = context;
            _dbSet = _context.Set<Receita>();
        }

        public async Task Adicionar(Receita receita)
        {
            await _dbSet.AddAsync(receita);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Receita receita)
        {
            _dbSet.Update(receita);
            await _context.SaveChangesAsync();
        }

        public async Task<Receita?> ObterPorId(Guid id)
        {
            var receita = await _dbSet.FindAsync(id);
            return receita;
        }

        public async Task<List<Receita>> ObterTodos()
        {
            var listaReceita = await _dbSet.ToListAsync();
            return listaReceita;
        }

        public async Task Remover(Guid id)
        {
            var receita = await ObterPorId(id);

            _dbSet.Remove(receita!);
            await _context.SaveChangesAsync();
        }
    }
}