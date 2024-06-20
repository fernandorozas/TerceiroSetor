namespace TerceiroSetor.Domain.Entities.Shared
{
    public class Banco : EntidadeFixa
    {
        protected Banco() { }

        public Banco(string descricao)
        {
            Descricao = descricao;
        }
        public string Descricao { get; private set; }
    }
}
