namespace TerceiroSetor.Domain.Entities.Procedimentos
{
    public class AdequacaoOrcamentaria : EntidadeBase
    {
        protected AdequacaoOrcamentaria() { }
        public AdequacaoOrcamentaria(string classificacaoInstitucional, 
            string classificacaoFuncional, string classificacaoEconomica, decimal valor)
        {
            ClassificacaoInstitucional = classificacaoInstitucional;
            ClassificacaoFuncional = classificacaoFuncional;
            ClassificacaoEconomica = classificacaoEconomica;
            Valor = valor;
        }

        public InstrumentoConvocatorio InstrumentoConvocatorio { get; private set; }
        public string ClassificacaoInstitucional { get; private set; }
        public string ClassificacaoFuncional { get; private set; }
        public string ClassificacaoEconomica { get; private set; }
        public decimal Valor { get; private set; }
    }
}
