using System.ComponentModel.DataAnnotations;

namespace DesafioPostosDeVacina.Application.DTOs
{
    public class VacinaDTO
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "O fabricante é obrigatório.")]
        public string Fabricante { get; set; }

        //[Required(ErrorMessage = "O lote é obrigatório.")]
        //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "O lote deve conter apenas letras e números.")]
        public string Lote { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

       // [Required(ErrorMessage = "A data de validade é obrigatória.")]
        //[DataType(DataType.Date, ErrorMessage = "Data de validade inválida.")]
        //[FutureDate(ErrorMessage = "A data de validade deve ser uma data futura.")]
        public DateTime DataValidade { get; set; }

        public int PostoDTOId { get; set; }
        //public PostoDTO PostoDTO { get; set; }
    }
}
