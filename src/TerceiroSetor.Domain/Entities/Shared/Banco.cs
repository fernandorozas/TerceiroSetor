using FluentValidation;

namespace TerceiroSetor.Domain.Entities.Shared
{
    public class Banco : EntidadeFixa
    {
        protected Banco() { }

        public Banco(string descricao)
        {
            Descricao = descricao;
        }
        public string Descricao { get; private set; }
    }

    public class ValidatorBancoValido : AbstractValidator<Banco>
    {
        public ValidatorBancoValido()
        {
            RuleFor(x => x.Descricao)
                 .NotEmpty().WithMessage("O campo Descricao precisa ser fornecido");

        }
    }


}
