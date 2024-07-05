using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class Responsavel 
    {
        public Responsavel() { }

        public Responsavel(OrganizacaoSocial organizacaoSocial, string nomeCompleto, string cpf, string emailPessoal, string emailInstitucional, VinculoTrabalhista vinculoTrabalhista, DateTime inicioVigencia, DateTime finalVigencia, Guid usuarioId)
        {
            OrganizacaoSocial = organizacaoSocial;
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            EmailPessoal = emailPessoal;
            EmailInstitucional = emailInstitucional;
            VinculoTrabalhista = vinculoTrabalhista;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            UsuarioId = usuarioId;
        }
        public Responsavel( string nomeCompleto, string cpf, string emailPessoal, string emailInstitucional, VinculoTrabalhista vinculoTrabalhista, DateTime inicioVigencia, DateTime finalVigencia, Guid usuarioId)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            EmailPessoal = emailPessoal;
            EmailInstitucional = emailInstitucional;
            VinculoTrabalhista = vinculoTrabalhista;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            UsuarioId = usuarioId;
        }

        public OrganizacaoSocial OrganizacaoSocial { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public string EmailPessoal { get; private set; }
        public string EmailInstitucional { get; private set; }
        public VinculoTrabalhista VinculoTrabalhista { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public Guid UsuarioId { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }
        public bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }
        private void Validate()
        {
            ValidationResult = new ValidatorResponsavelValido().Validate(this);
        }

        public void InformarUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;


        public  bool ValidarCpf(string cpf)
        {
            if (cpf != null)
            {
                if (cpf.Length > 11) return false;
                while (cpf.Length != 11)
                    cpf = '0' + cpf;
                var igual = true;
                for (var i = 1; i < 11 && igual; i++)
                    if (cpf[i] != cpf[0])
                        igual = false;
                if (igual || cpf == "12345678909") return false;
                var numeros = new int[11];
                for (var i = 0; i < 11; i++)
                    numeros[i] = int.Parse(cpf[i].ToString());
                var soma = 0;
                for (var i = 0; i < 9; i++)
                    soma += (10 - i) * numeros[i];
                var resultado = soma % 11;
                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[9] != 0) return false;
                }
                else if (numeros[9] != 11 - resultado)
                    return false;
                soma = 0;
                for (var i = 0; i < 10; i++)
                    soma += (11 - i) * numeros[i];
                resultado = soma % 11;
                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[10] != 0)
                        return false;
                }
                else if (numeros[10] != 11 - resultado)
                    return false;
            }
            return true;
        }

    }

    public class ValidatorResponsavelValido : AbstractValidator<Responsavel>
    {

        private bool ValidarCpf(string cpf)
        {
            var resp = new Responsavel();
            return resp.ValidarCpf(cpf);
        }
        public ValidatorResponsavelValido()
        {
            RuleFor(x => x.NomeCompleto)
                .NotEmpty().WithMessage("O campo NomeCompleto precisa ser fornecido")
                .Length(5, 250).WithMessage("O campo NomeCompleto precisa ter entre 5 e 250 caracteres");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O campo Cpf precisa ser fornecido")
                .Must(ValidarCpf).WithMessage("CPF inválido");

            RuleFor(x => x.EmailPessoal)
                .NotEmpty().WithMessage("O campo EmailPessoal precisa ser fornecido")
                .EmailAddress().WithMessage("EmailPessoal em formato inválido")
                .MaximumLength(250).WithMessage("O campo EmailPessoal pode ter no máximo 250 caracteres");

            RuleFor(x => x.EmailInstitucional)
                .EmailAddress().WithMessage("EmailInstitucional em formato inválido");

            RuleFor(x => x.InicioVigencia)
                .NotEmpty().WithMessage("O campo InicioVigencia precisa ser fornecido");

            RuleFor(x => x.FinalVigencia)
                .NotEmpty().WithMessage("O campo FinalVigencia precisa ser fornecido")
                .GreaterThan(x => x.InicioVigencia).WithMessage("A data de fim de vigência deve ser maior que a data de início.");
        }
    }
    

}
