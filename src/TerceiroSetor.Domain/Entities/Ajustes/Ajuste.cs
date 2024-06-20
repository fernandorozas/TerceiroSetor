using TerceiroSetor.Domain.Entities.Contratos;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.Domain.Entities.Publicacoes;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class Ajuste : EntidadeBase
    {
        protected Ajuste() { }
        public string CodigoAjusteTCE { get; private set; }
        public TipoAjuste TipoAjuste { get; private set; }
        public OrganizacaoSocial OrganizacaoSocial { get; private set; }
        public string NumeroAjuste { get; private set; }
        public DateTime DataAssinatura { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public decimal ValorGlobal { get; private set; }
        public string LegislacaoRegulamentadora { get; private set; }
        public string Objeto{ get; private set; }
        public bool AtuacaoEmRede { get; private set; }
        public ICollection<Empenho> Empenhos { get; private set; }
        public ICollection<ClausulaContratual> ClausulasContratuais { get; private set; }
        public ICollection<Convenio> Convenios { get; private set; }
        public ICollection<BemCedido> BensCedidos { get; private set; }
        public ICollection<Assinante> Assinantes { get; private set; }
        public ICollection<Contrato> Contratos { get; private set; }
        public ICollection<Arquivo> Arquivos { get; private set; }
        public ICollection<Publicacao> Publicacoes { get; private set; }
  
    }
}
