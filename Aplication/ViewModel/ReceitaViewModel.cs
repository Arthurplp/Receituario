using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Models
{
    public class ReceitaViewModel : Controller
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int UnidadeDeMedida { get; set; }
    }
}
