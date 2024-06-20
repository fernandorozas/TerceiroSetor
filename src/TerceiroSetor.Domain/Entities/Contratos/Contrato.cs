using TerceiroSetor.Domain.Entities.Ajustes;
using TerceiroSetor.Domain.Entities.Publicacoes;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.Contratos
{
    public class Contrato : EntidadeBase
    {
        public Contrato() { }
        public Contrato(Credor credor, string numero, DateTime dataAssinatura, 
            DateTime inicioVigencia, DateTime finalVigencia, string objeto, 
            NaturezaContratacao naturezaContratacao, string outraNatureza, 
            CriterioSelecao criterioSelecao, string outroCriterio, 
            string artigoRegulamentoCompras, decimal valorMontante, TipoValor tipoValor)
        {
            Credor = credor;
            Numero = numero;
            DataAssinatura = dataAssinatura;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            Objeto = objeto;
            NaturezaContratacao = naturezaContratacao;
            OutraNatureza = outraNatureza;
            CriterioSelecao = criterioSelecao;
            OutroCriterio = outroCriterio;
            ArtigoRegulamentoCompras = artigoRegulamentoCompras;
            ValorMontante = valorMontante;
            TipoValor = tipoValor;
        }
        public Ajuste Ajuste { get; private set; }
        public Credor Credor { get; private set; }
        public string Numero { get; private set; }
        public DateTime DataAssinatura { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public string Objeto { get; private set; }
        public NaturezaContratacao NaturezaContratacao { get; private set; }
        public string OutraNatureza { get; private set; }
        public CriterioSelecao CriterioSelecao { get; private set; }
        public string OutroCriterio { get; private set; }
        public string ArtigoRegulamentoCompras { get; private set; }
        public decimal ValorMontante { get; private set; }
        public TipoValor TipoValor { get; private set; }
        public ICollection<Arquivo> Arquivos { get; private set; }
        public ICollection<Publicacao> Publicacoes { get; private set; }

    }
}
