namespace Domínio.Model
{
    public class Receita
    {
        public  Guid Id { get; set; }
        public Guid? IdReceitaPai { get; set; }
        public Guid? IdUnidadeMedida { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public List<Receita>? SubReceitas { get; set; }
        public List<VinculoReceitaMaterial>? Vinculos { get; set; }
        public decimal PesoTotal { get; set; }
        public UnidadeDeMedida UnidadeMedida { get; set; } = null!;
        public Receita? ReceitaPai { get; set; }

        public Receita() { }

        public Receita(string descricao, string nome, decimal pesoTotal, UnidadeDeMedida unidadeMedida)
        {
            this.Id = Guid.NewGuid();
            this.Descricao = descricao;
            this.Nome = nome;
            this.PesoTotal = pesoTotal;
            this.UnidadeMedida = unidadeMedida;
            this.IdUnidadeMedida = unidadeMedida.Id;
        }
    }
}