using FluentValidation;
using TerceiroSetor.Domain.Entities.Shared;
using TerceiroSetor.Domain.ValueObjects;

namespace TerceiroSetor.Domain.Entities.Shared
{
    public class Pessoa
    {
        protected Pessoa() { }

        public Pessoa(string nomeCompleto, string cpf, string emailPessoal, string emailInstitucional, Endereco endereco)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            EmailPessoal = emailPessoal;
            EmailInstitucional = emailInstitucional;
            Endereco = endereco;
        }

        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public string EmailPessoal { get; private set; }
        public string EmailInstitucional { get; private set; }
        public Endereco Endereco { get; private set; }
        public Guid UsuarioId { get; private set; }
        public void InformarUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;
    }
}

public class ValidatorPessoaValido : AbstractValidator<Pessoa>
{

    private bool ValidarCpf(string numero)
    {
        if (numero.Length > 11) return false;

        while (numero.Length != 11)
            numero = '0' + numero;

        var igual = true;
        for (var i = 1; i < 11 && igual; i++)
            if (numero[i] != numero[0])
                igual = false;

        if (igual || numero == "12345678909") return false;

        var numeros = new int[11];

        for (var i = 0; i < 11; i++)
            numeros[i] = int.Parse(numero[i].ToString());

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
        return true;
    }

    public ValidatorPessoaValido()
    {
        RuleFor(c => c.NomeCompleto)
            .NotEmpty().WithMessage("O campo NomeCompleto precisa ser fornecido")
            .Length(5, 250).WithMessage("O campo NomeCompleto precisa ter entre 5 e 250 caracteres");


        RuleFor(x => x.EmailPessoal)
            .EmailAddress().WithMessage("EmailPessoal em formato inválido")
            .MaximumLength(250).WithMessage("O campo EmailPessoal pode ter no máximo 250 caracteres");

        RuleFor(x => x.EmailInstitucional)
            .EmailAddress().WithMessage("EmailInstitucional em formato inválido")
            .MaximumLength(250).WithMessage("O campo EmailInstitucional pode ter no máximo 250 caracteres");

        RuleFor(x => x.Cpf)
        .NotEmpty().WithMessage("O campo CPF precisa ser fornecido")
        .Must(ValidarCpf).WithMessage("CPF inválido");

        RuleFor(x => x.Endereco).SetValidator(new ValidatorEnderecoValido());
        
    }
}