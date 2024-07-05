using FluentValidation;

namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class Conselho
    {
        protected Conselho() { }
        public Conselho(int tipoConselho, DateTime inicioVigencia, 
            DateTime finalVigencia, ICollection<ConselhoMembro> membros)
        {
            TipoConselho = (TipoConselho)tipoConselho;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            Membros = membros;
        }

        public TipoConselho TipoConselho { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public ICollection<ConselhoMembro> Membros { get; private set; }
        public void EncerrarVigencia(DateTime dataEncerramento) => FinalVigencia = dataEncerramento;
        
    }

    public class ValidatorConselhoValido : AbstractValidator<Conselho>
    {
        public ValidatorConselhoValido()
        {
            RuleFor(x => x.InicioVigencia)
                 .NotEmpty()
                 .GreaterThanOrEqualTo(new DateTime(2024,01,01))
                 .WithMessage("Data de inicio de vigência deve ser maior que a data de instituição da entidade");
        }
    }

}
