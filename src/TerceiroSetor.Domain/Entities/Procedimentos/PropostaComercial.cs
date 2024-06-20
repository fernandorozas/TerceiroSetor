using TerceiroSetor.Domain.Entities.OrganizacoesSociais;

namespace TerceiroSetor.Domain.Entities.Procedimentos
{
    public class PropostaComercial : EntidadeBase
    {
        protected PropostaComercial() { }
        public PropostaComercial(OrganizacaoSocial organizacaoSocial, 
            bool selecionado, decimal valor, bool comprovacaoTempoMinimo, 
            bool representacaoExamePrevioTCE, string numeroETCESP, string relator)
        {
            OrganizacaoSocial = organizacaoSocial;
            Selecionado = selecionado;
            Valor = valor;
            ComprovacaoTempoMinimo = comprovacaoTempoMinimo;
            RepresentacaoExamePrevioTCE = representacaoExamePrevioTCE;
            NumeroETCESP = numeroETCESP;
            Relator = relator;
        }

        public OrganizacaoSocial OrganizacaoSocial { get; private set; }

        public InstrumentoConvocatorio InstrumentoConvocatorio { get; private set; }
        public bool Selecionado { get; private set; }
        public decimal Valor { get; private set; }
        public bool ComprovacaoTempoMinimo { get; private set; }
        public bool RepresentacaoExamePrevioTCE { get; private set; }
        public string NumeroETCESP { get; private set; }
        public string Relator { get; private set; }
    }
}
