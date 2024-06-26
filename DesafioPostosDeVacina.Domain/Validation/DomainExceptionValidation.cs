namespace DesafioPostosDeVacina.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string erro) : base(erro) { }

        public static void When(bool temErro, string erro)
        {
            if (temErro)
            {
                throw new DomainExceptionValidation(erro);
            }
        }
    }
}
