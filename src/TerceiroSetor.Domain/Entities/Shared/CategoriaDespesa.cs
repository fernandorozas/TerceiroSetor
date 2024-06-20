namespace TerceiroSetor.Domain.Entities.Shared
{
    public class CategoriaDespesa : EntidadeFixa
    {
        protected CategoriaDespesa() { }

        public CategoriaDespesa(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; private set; }
    }
}
