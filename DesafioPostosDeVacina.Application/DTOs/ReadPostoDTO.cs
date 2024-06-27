using System.ComponentModel.DataAnnotations;

namespace DesafioPostosDeVacina.Application.DTOs
{
    public class ReadPostoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ReadVacinaDTO> Vacinas { get; set; }
    }
}
