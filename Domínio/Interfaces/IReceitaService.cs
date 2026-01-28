using Domínio.Model;

namespace Domínio.Interfaces
{
    //aqui a gente cria os métodos que eu vou utilizar na service 

    public interface IReceitaService
    {
        Task<List<Receita>> GetReceitas();
        Task<Receita>? GetById(Guid Id);
        Task Delete(Guid Id);
        Task<Receita> Create(Receita receita);
        Task<Receita> Edit(Receita receita);
    }
}