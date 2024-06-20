namespace TerceiroSetor.Domain.Entities.Publicacoes
{
    public class Publicacao : EntidadeBase
    {
        protected Publicacao() { }

        public Publicacao(OrgaoPublicacao orgaoPublicacao, TipoPublicacao tipoPublicacao, 
            DateTime dataPublicacao, string url)
        {
            OrgaoPublicacao = orgaoPublicacao;
            TipoPublicacao = tipoPublicacao;
            DataPublicacao = dataPublicacao;
            Url = url;
        }

        public OrgaoPublicacao OrgaoPublicacao { get; private set; }
        public TipoPublicacao TipoPublicacao { get; private set; }
        public DateTime DataPublicacao { get; private set; }
        public string Url { get; private set; }
    }
}
