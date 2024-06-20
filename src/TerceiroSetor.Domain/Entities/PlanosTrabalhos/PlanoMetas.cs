namespace TerceiroSetor.Domain.Entities.PlanosTrabalhos
{
    public class PlanoMetas : EntidadeBase
    {
        protected PlanoMetas() { }
        public PlanoMetas(string programa, string unidadeMedida, decimal quantidade)
        {
            Programa = programa;
            UnidadeMedida = unidadeMedida;
            Quantidade = quantidade;
        }

        public PlanoTrabalho PlanoTrabalho { get; private set; }
        public string Programa { get; private set; }
        public string UnidadeMedida { get; private set; }
        public decimal Quantidade { get; private set; }

    }
}
