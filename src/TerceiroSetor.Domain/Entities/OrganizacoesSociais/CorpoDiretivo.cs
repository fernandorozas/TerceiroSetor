using FluentValidation;

namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class CorpoDiretivo
    {
        public CorpoDiretivo() { }
        public CorpoDiretivo(DateTime inicioVigencia, DateTime finalVigencia, 
            ICollection<CorpoDiretivoMembro> membros)
        {
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            Membros = membros;
        }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public ICollection<CorpoDiretivoMembro> Membros { get; private set; }
    }

    public class ValidatorCorpoDiretivoValido : AbstractValidator<CorpoDiretivo>
    {
        public ValidatorCorpoDiretivoValido()
        {
            RuleFor(x => x.InicioVigencia)
                 .NotEmpty().WithMessage("O campo InicioVigencia precisa ser fornecido");

            RuleFor(x => x.FinalVigencia)
                .NotEmpty().WithMessage("O campo FinalVigencia precisa ser fornecido")
                .GreaterThan(x => x.InicioVigencia).WithMessage("A data de fim de vigência deve ser maior que a data de início.");
        }
    }

}
