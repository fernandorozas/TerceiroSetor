using FluentValidation;
using TerceiroSetor.Domain.ValueObjects;

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
    }

    public class ValidatorConselhoValido : AbstractValidator<Conselho>
    {
        public ValidatorConselhoValido()
        {
            RuleFor(x => x.InicioVigencia)
                 .NotEmpty().WithMessage("O campo InicioVigencia precisa ser fornecido");

            RuleFor(x => x.FinalVigencia)
                .NotEmpty().WithMessage("O campo FinalVigencia precisa ser fornecido")
                .GreaterThan(x => x.InicioVigencia).WithMessage("A data de fim de vigência deve ser maior que a data de início.");

            RuleForEach(x => x.Membros).SetValidator(new ValidatorConselhoMembroValido());
        }
    }

}
