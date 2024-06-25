using System.ComponentModel.DataAnnotations;

namespace DesafioPostosDeVacina.Application.DTOs
{
    public class PostoDTO
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        //public ICollection<VacinaDTO> VacinaDTOs { get; set; }
    }
}
