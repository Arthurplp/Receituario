using Domínio.Model;

namespace Domínio.Interfaces
{
    public interface IRepositorioReceita
    {
        Task Adicionar(Receita receita);
        Task<Receita?> ObterPorId(Guid id);
        Task<List<Receita>> ObterTodos();
        Task Atualizar(Receita receita);
        Task Remover(Guid id);
    }
}