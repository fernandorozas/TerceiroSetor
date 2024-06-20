namespace TerceiroSetor.Domain.Entities.Shared
{
    public class FonteRecurso : EntidadeFixa
    {
        protected FonteRecurso() { }

        public FonteRecurso(string descricao)
        {
            Descricao = descricao;
        }
        public string Descricao { get; private set; }
    }
}
