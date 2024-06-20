using TerceiroSetor.Domain.Entities.Comissoes;
using TerceiroSetor.Domain.Entities.Publicacoes;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.Procedimentos
{
    public class InstrumentoConvocatorio : EntidadeBase
    {
        protected InstrumentoConvocatorio() { }
        public InstrumentoConvocatorio(TipoInstrumento tipoInstrumento, 
            AdequacaoOrcamentaria adequacaoOrcamentaria, Comissao comissaoSelecao)
        {
            TipoInstrumento = tipoInstrumento;
            AdequacaoOrcamentaria = adequacaoOrcamentaria;
            ComissaoSelecao = comissaoSelecao;
        }

        public TipoInstrumento TipoInstrumento { get; private set; }
        public DateTime DataExpedicao { get; set; }
        public Comissao ComissaoSelecao { get; private set; }
        public AdequacaoOrcamentaria AdequacaoOrcamentaria { get; private set; }
        public ICollection<PropostaComercial> Propostas { get; private set; }
        public ICollection<Arquivo> Arquivos { get; private set; }
        public ICollection<Publicacao> Publicacoes { get; private set; }

    }
}
