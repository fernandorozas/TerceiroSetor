using FluentValidation.Results;
using TerceiroSetor.Domain.Entities.Shared;
using TerceiroSetor.Domain.ValueObjects;

namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class OrganizacaoSocial : EntidadeBase
    {
        public OrganizacaoSocial() { }
        public OrganizacaoSocial(string nome, int tipoOrganizacaoSocial,
            DateTime dataConstituicao, Endereco endereco, string telefone, string cnpj,
            string artigoReferencia, string finalidadeResumida, Finalidade finalidade)
        {
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
        public DateTime DataConstituicao { get; private set; }
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

        protected override void Validate()
        {
            ValidationResult = new ValidationResult();
        }
        public void InformarConselho(Conselho conselho) => Conselhos.Add(conselho);
        public void InformarResponsavel(Responsavel responsavel) => Responsaveis.Add(responsavel);
    }
}
