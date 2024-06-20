namespace TerceiroSetor.Domain.Entities.Shared
{
    public class ClassificacaoDespesa : EntidadeFixa
    {
        protected ClassificacaoDespesa() { }

        public ClassificacaoDespesa(string sigla, string descricao)
        {
            Sigla = sigla;
            Descricao = descricao;
        }

        public string Sigla { get; private set; }
        public string Descricao { get; private set; }
    }
}
