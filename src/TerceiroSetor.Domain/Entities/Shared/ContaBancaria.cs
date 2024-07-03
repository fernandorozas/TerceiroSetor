using FluentValidation;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;

namespace TerceiroSetor.Domain.Entities.Shared
{
    public class ContaBancaria
    {
        protected ContaBancaria() {}

        public ContaBancaria(Banco banco, string agencia, string contaCorrente, TipoConta tipoConta)
        {
            Banco = banco;
            Agencia = agencia;
            ContaCorrente = contaCorrente;
            TipoConta = tipoConta;
        }

        public Banco Banco { get; private set; }
        public string Agencia { get; private set; }
        public string ContaCorrente { get; private set; }
        public TipoConta TipoConta { get; private set; }

    }

    public class ValidatorContaBancariaValido : AbstractValidator<ContaBancaria>
    {
        public ValidatorContaBancariaValido()
        {
            RuleFor(x => x.Agencia)
                 .NotEmpty().WithMessage("O campo Agencia precisa ser fornecido");
            
            RuleFor(x => x.ContaCorrente)
                 .NotEmpty().WithMessage("O campo Conta Corrente precisa ser fornecido");

            RuleFor(x => x.Banco).SetValidator(new ValidatorBancoValido());

        }
    }

}
