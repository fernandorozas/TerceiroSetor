using TerceiroSetor.Domain.Entities.Comissoes;
using TerceiroSetor.Domain.Entities.Contratos;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.NotasFiscais
{
    public class NotaFiscal: EntidadeBase
    {
        protected NotaFiscal() { }
        public NotaFiscal(Credor credor, string numero, string descricao, 
            decimal valorBruto, decimal valorEncargos, CategoriaDespesa categoriaDespesa, 
            TipoRateio tipoRateio, decimal precentualRateio, 
            Comissao comissaoAvaliacao, SituacaoAnalise situacaoAnalise)
        {
            Credor = credor;
            Numero = numero;
            Descricao = descricao;
            ValorBruto = valorBruto;
            ValorEncargos = valorEncargos;
            CategoriaDespesa = categoriaDespesa;
            TipoRateio = tipoRateio;
            PrecentualRateio = precentualRateio;
            ComissaoAvaliacao = comissaoAvaliacao;
            SituacaoAnalise = situacaoAnalise;
        }

        public Credor Credor { get; private set; }
        public Contrato Contrato { get; private set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorEncargos { get; set; }
        public CategoriaDespesa CategoriaDespesa { get; private set; }
        public TipoRateio TipoRateio { get; set; }
        public decimal PrecentualRateio { get; set; }
        public Comissao ComissaoAvaliacao { get; private set; }
        public SituacaoAnalise SituacaoAnalise { get; set; }
    }
}
