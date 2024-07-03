using FluentValidation;
using FluentValidation.Results;
using System.Runtime.ConstrainedExecution;
using TerceiroSetor.Domain.Entities.Shared;
using TerceiroSetor.Domain.ValueObjects;

namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class OrganizacaoSocial : EntidadeBase
    {
        public OrganizacaoSocial() { }
        public OrganizacaoSocial(string nome, 
                                int tipoOrganizacaoSocial,
                                DateTime? dataConstituicao, 
                                Endereco endereco, 
                                string telefone, 
                                string cnpj, 
                                string artigoReferencia, 
                                string finalidadeResumida, 
                                Finalidade finalidade)
        {

           /* if (!ValidarCnpj(cnpj))
            {
                throw new ArgumentException("Cnpj inválido.");
            }*/

            Nome = nome;
            TipoOrganizacaoSocial = (TipoOrganizacaoSocial)tipoOrganizacaoSocial;
            DataConstituicao = dataConstituicao;
            Endereco = endereco;
            Telefone = telefone;
            Cnpj = cnpj;
            ArtigoReferencia = artigoReferencia;
            FinalidadeResumida = finalidadeResumida;
            Finalidade = finalidade;
            Ativo = true;
        }

        public string Nome { get; private set; }
        public TipoOrganizacaoSocial TipoOrganizacaoSocial { get; private set; }
        public DateTime? DataConstituicao { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Cnpj { get; private set; }
        public string ArtigoReferencia { get; private set; }
        public string FinalidadeResumida { get; private set; }
        public Finalidade Finalidade { get; private set; } 
        public CorpoDiretivo CorpoDiretivo { get; private set; }
        public ICollection<Conselho> Conselhos { get; private set; } = new List<Conselho>();    
        public ICollection<Responsavel> Responsaveis { get; private set; } = new List<Responsavel>();
        public ICollection<ContaBancaria> Contas { get; private set; } = new List<ContaBancaria>();

        public  bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        protected override void Validate()   
        {
           ValidationResult = new ValidatorOrganizacoesSociaisValido().Validate(this);
        }
        public void InformarConselho(Conselho conselho) => Conselhos.Add(conselho);
        public void InformarResponsavel(Responsavel responsavel) => Responsaveis.Add(responsavel);
    }
    public class ValidatorOrganizacoesSociaisValido : AbstractValidator<OrganizacaoSocial>
    {

        private bool ValidarCnpj(string cnpj)
        {
            var organizacao = new OrganizacaoSocial();
            return organizacao.ValidarCnpj(cnpj);
        }

        internal ValidationResult Validate(Responsavel responsavel)
        {
            throw new NotImplementedException();
        }

        public ValidatorOrganizacoesSociaisValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo NomeCompleto precisa ser fornecido")
                .Length(5, 250).WithMessage("O campo NomeCompleto precisa ter entre 5 e 250 caracteres");

            RuleFor(x => x.ArtigoReferencia)
                .Length(5, 100).WithMessage("O campo ArtigoReferencia precisa ter entre 5 e 100 caracteres");

            RuleFor(x => x.FinalidadeResumida)
                .NotEmpty().WithMessage("O campo Finalidade Resumida precisa ser fornecido")
                .MaximumLength(250).WithMessage("O campo FinalidadeResumida pode ter no máximo 250 caracteres");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O campo Telefone precisa ser fornecido")
                .MaximumLength(15).WithMessage("O campo Telefone pode ter no máximo 15 caracteres");

            RuleFor(x => x.DataConstituicao)
                .NotEmpty().WithMessage("O campo DataConstituicao precisa ser fornecido");

            RuleFor(x => x.Telefone)
                            .NotEmpty().WithMessage("O campo Telefone precisa ser fornecido")
                            .MaximumLength(14).WithMessage("O campo Telefone pode ter no máximo 14 caracteres")
                            .Matches(@"^\d+$").WithMessage("O campo Telefone deve conter apenas números");

            RuleFor(x => x.CorpoDiretivo).SetValidator(new ValidatorCorpoDiretivoValido());
            
            RuleFor(x => x.Endereco).SetValidator(new ValidatorEnderecoValido());

            RuleFor(x => x.Cnpj)
               .NotEmpty().WithMessage("O campo CNPJ precisa ser fornecido")
               .Must(ValidarCnpj).WithMessage("CNPJ inválido");

            // RuleForEach(x => x.Conselhos).SetValidator(new ValidatorConselhoValido());
            // RuleForEach(x => x.Responsaveis).SetValidator(new ValidatorResponsavelValido());

        }

        
    }


}
