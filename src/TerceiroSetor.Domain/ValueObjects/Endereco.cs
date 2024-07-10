using FluentValidation;
using System.Text.RegularExpressions;

namespace TerceiroSetor.Domain.ValueObjects
{
    public class Endereco
    {
        protected Endereco() { }
        public Endereco(string cep, string logradouro, string numero, string complemento, 
            string bairro, string cidade, string estado)
        {
            if (!ValidarCep(cep))
            {
                throw new ArgumentException("CEP inválido.");
            }

            Cep = cep;
            Logradouro = logradouro;
            NumeroImovel = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string NumeroImovel { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public bool ValidarCep(string cep)
        {
            // Remova espaços em branco
            cep = cep.Replace(" ", "");
            // Verifique se o CEP possui 8 caracteres
            if (cep.Length != 8)
            {
                return false;
            }
            // Verifique se todos os caracteres são dígitos
            if (!Regex.IsMatch(cep, @"^\d+$"))
            {
                return false;
            }
            return true;
        }

        public void AlterarEndereco(    String cep ,
                                        String logradouro ,
                                        String numeroImovel ,
                                        String complemento , 
                                        String bairro,
                                        String cidade,
                                        String estado )
        { 
            Cep = cep;  
            Logradouro = logradouro;
            NumeroImovel = numeroImovel;
            Complemento = complemento;  
            Bairro = bairro;        
            Cidade = cidade;
            Estado = estado;    
        }
    }

    public class ValidatorEnderecoValido : AbstractValidator<Endereco>
    {
        public ValidatorEnderecoValido()                  
        {

            RuleFor(endereco => endereco.Cep)
                            .NotEmpty().WithMessage("O campo Cep precisa ser fornecido")
                            .Length(8).WithMessage("O campo Cep precisa ter 8 caracteres")
                            .Must((endereco, cep) => endereco.ValidarCep(cep)).WithMessage("CEP inválido");

            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O campo Logradouro precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo Logradouro precisa ter entre 2 e 100 caracteres");

            RuleFor(c => c.NumeroImovel)
                .NotEmpty().WithMessage("O campo Número precisa ser fornecido")
                .Length(1, 20).WithMessage("O campo Número precisa ter entre 1 e 20 caracteres");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O campo Bairro precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo Bairro precisa ter entre 2 e 100 caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("A campo Cidade precisa ser fornecida")
                .Length(3, 30).WithMessage("O campo Cidade precisa ter entre 3 e 30 caracteres");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O campo Estado precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo Estado precisa ter entre 2 e 2 caracteres");

            RuleFor(c => c.Complemento).MaximumLength(100).WithMessage("O campo Complemento precisa ter no máximo 100 caracteres");
        }
    
    }


}
