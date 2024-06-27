using DesafioPostosDeVacina.Domain.Validation;

namespace DesafioPostosDeVacina.Domain.Entities
{
    public class Posto : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Vacina> Vacinas { get; set; }

        public Posto( string nome)
        {
            ValidateDomain(nome);
        }

        public Posto(int id,string nome)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido! Id menor que zero.");
            Id = id;
            ValidateDomain(nome);
        }

        public void Update(string nome)
        {
            ValidateDomain(nome);
        }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. Nome é obrigatório!");

            DomainExceptionValidation.When(nome.Length < 3,
                "Nome inválido, muito pequeno, mínimo 3 letras!");

            Nome = nome;
        }
    }
}
