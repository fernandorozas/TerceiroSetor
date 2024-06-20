namespace TerceiroSetor.Domain.Entities.Shared
{
    public class Cargo : EntidadeFixa
    {
        protected Cargo() { }

        public Cargo(string descricao)
        {
            Descricao = descricao;
        }
        public string Descricao { get; private set; }
    }
}
