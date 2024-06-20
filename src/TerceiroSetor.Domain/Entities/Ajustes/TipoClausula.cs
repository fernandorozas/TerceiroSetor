namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class TipoClausula : EntidadeFixa
    {
        public TipoClausula() {}
        public TipoClausula(string descricao)
        {
            Descricao = descricao;
        }
        public string Descricao { get; set; }
    }
}
