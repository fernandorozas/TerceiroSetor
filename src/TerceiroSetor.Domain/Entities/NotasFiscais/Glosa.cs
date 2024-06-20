namespace TerceiroSetor.Domain.Entities.NotasFiscais
{
    public class Glosa: EntidadeBase
    {
        protected Glosa() { }
        public Glosa(TipoGlosa tipoGlosa, decimal valorGlosa)
        {
            TipoGlosa = tipoGlosa;
            ValorGlosa = valorGlosa;
        }
        public NotaFiscal NotaFiscal { get; set; }
        public TipoGlosa TipoGlosa { get; set; }
        public decimal ValorGlosa { get; set; }
    }
}
