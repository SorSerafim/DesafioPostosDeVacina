using DesafioPostosDeVacina.Domain.Validation;

namespace DesafioPostosDeVacina.Domain.Entities
{
    public class Vacina : Entity
    {
        public string Nome { get; protected set; }
        public string Fabricante { get; protected set; }
        public string Lote { get; protected set; }
        public int Quantidade { get; protected set; }
        public DateTime DataValidade { get; protected set; }
        public int PostoId { get; set; }
        public virtual Posto Posto { get; set; }

        public Vacina(string nome, string fabricante, string lote, int quantidade, DateTime dataValidade)
        {
            ValidateDomain(nome, fabricante, lote, quantidade, dataValidade);
        }

        public Vacina(int id,string nome, string fabricante, string lote, int quantidade, DateTime dataValidade)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido! Id menor que zero.");
            Id = id;
            ValidateDomain(nome, fabricante, lote, quantidade, dataValidade);
        }

        public void Update(string nome, string fabricante, string lote, int quantidade, DateTime dataValidade, int postoId)
        {
            ValidateDomain(nome, fabricante, lote, quantidade, dataValidade);
            PostoId = postoId;
        }

        private void ValidateDomain(string nome, string fabricante, string lote, int quantidade, DateTime dataValidade)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. Nome é obrigatório!");

            DomainExceptionValidation.When(nome.Length < 3,
                "Nome inválido, muito pequeno, mínimo 3 letras!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(fabricante),
                "Fabricante inválido. Fabricante é obrigatório!");

            DomainExceptionValidation.When(fabricante.Length < 3,
                "Fabricante inválido, muito pequeno, mínimo 3 letras!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(lote),
                "Lote inválido. Lote é obrigatório!");

            DomainExceptionValidation.When(lote.Length < 4 || lote.Length > 12,
                "Lote inválido, tem que ter entre 4 e 12 letras!");

            DomainExceptionValidation.When(quantidade <= 0,
                "Quantidade inválida. Quantidade deve ser maior que zero!");

            DomainExceptionValidation.When(dataValidade <= DateTime.Now,
                "Data de validade inválida. A data de validade deve ser uma data futura!");

            Nome = nome;
            Fabricante = fabricante;
            Lote = lote;
            Quantidade = quantidade;
            DataValidade = dataValidade;
        }

    }
}
