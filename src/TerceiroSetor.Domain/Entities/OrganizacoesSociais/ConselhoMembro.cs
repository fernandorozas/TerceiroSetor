using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class ConselhoMembro
    {
        protected ConselhoMembro() { }
        public ConselhoMembro(Pessoa pessoa, DateTime inicioVigencia, DateTime finalVigencia)
        {
            Pessoa = pessoa;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
        }
        public Conselho Conselho { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }
        public bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }
        private void Validate()
        {
            ValidationResult = new ValidatorConselhoMembroValido().Validate(this);
        }
    }

    public class ValidatorConselhoMembroValido : AbstractValidator<ConselhoMembro>
    {
        public ValidatorConselhoMembroValido()
        {

            RuleFor(x => x.InicioVigencia)
                 .NotEmpty().WithMessage("O campo InicioVigencia precisa ser fornecido");

            RuleFor(x => x.FinalVigencia)
                //.NotEmpty().WithMessage("O campo FinalVigencia precisa ser fornecido")
                .GreaterThan(x => x.InicioVigencia).WithMessage("A data de fim de vigência deve ser maior que a data de início.");

            RuleFor(x => x.Pessoa).SetValidator(new ValidatorPessoaValido());
            RuleFor(x => x.Conselho).SetValidator(new ValidatorConselhoValido());
        }
    }


}
