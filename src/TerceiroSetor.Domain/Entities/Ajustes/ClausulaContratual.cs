namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class ClausulaContratual : EntidadeBase
    {
        protected ClausulaContratual() { }
        public ClausulaContratual(Ajuste ajuste, TipoClausula tipoClausula, string numero)
        {
            Ajuste = ajuste;
            TipoClausula = tipoClausula;
            Numero = numero;
        }

        public Ajuste Ajuste { get; private set; }
        public TipoClausula TipoClausula { get; private set; }
        public string  Numero { get; private set; }

    }
}
