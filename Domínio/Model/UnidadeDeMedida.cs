namespace Domínio.Model
{
    public class UnidadeDeMedida
    {
        public Guid Id { get; set; }
        public string Identificador { get; set; } = null!;
        public string Descricao { get; set; } = null!;

        public UnidadeDeMedida() { }

        public UnidadeDeMedida(string identificador, string descricao)
        {
            this.Id = Guid.NewGuid();
            this.Identificador = identificador;
            this.Descricao = descricao;
        }
    }
}