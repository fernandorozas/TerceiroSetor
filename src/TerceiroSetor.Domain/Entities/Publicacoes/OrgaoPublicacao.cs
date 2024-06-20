namespace TerceiroSetor.Domain.Entities.Publicacoes
{
    public class OrgaoPublicacao : EntidadeBase
    {
        protected OrgaoPublicacao() { }

        public OrgaoPublicacao(TipoOrgaoPublicacao tipoOrgaoPublicacao, string nome)
        {
            TipoOrgaoPublicacao = tipoOrgaoPublicacao;
            Nome = nome;
        }

        public TipoOrgaoPublicacao TipoOrgaoPublicacao { get; private set; }
        public string Nome { get; set; }

    }
}
