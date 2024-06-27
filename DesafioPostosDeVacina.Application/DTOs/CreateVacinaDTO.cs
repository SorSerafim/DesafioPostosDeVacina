using System.ComponentModel.DataAnnotations;

namespace DesafioPostosDeVacina.Application.DTOs
{
    public class CreateVacinaDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Fabricante é obrigatório!")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "O campo Lote é obrigatório!")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "O lote deve conter apenas letras e números.")]
        public string Lote { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "A data de validade é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data de validade inválida.")]
        [FutureDate(ErrorMessage = "A data de validade deve ser uma data futura.")]
        public DateTime DataValidade { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "PostoId deve ser maior que zero e de um posto existente!.")]
        public int PostoId { get; set; }
    }
}
