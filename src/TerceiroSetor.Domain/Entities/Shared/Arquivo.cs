namespace TerceiroSetor.Domain.Entities.Shared
{
    public class Arquivo: EntidadeBase
    {
        protected Arquivo() {}
        public Arquivo(string url)
        {
            Url = url;
        }

        public string Url { get; private set; }

    }
}
