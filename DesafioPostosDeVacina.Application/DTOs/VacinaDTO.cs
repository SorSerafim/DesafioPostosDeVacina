using System.ComponentModel.DataAnnotations;

namespace DesafioPostosDeVacina.Application.DTOs
{
    public class VacinaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public string Lote { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }
        public int PostoId { get; set; }
    }
}
