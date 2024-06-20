namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class Declaracao : EntidadeBase
    {
        protected Declaracao() { }
        public Declaracao(Ajuste ajuste, bool comprovacaoArtigo33V, 
            bool comprovacaoArtigo35III, bool comprovacaoArtigo35V, 
            bool comprovacaoArtigo35VI, bool membroAdministracaoPublica, 
            bool comprovacaoArtigo34, bool organizacaoSocialImpedida, 
            bool existenciaTermoCienciaNotificacao)
        {
            Ajuste = ajuste;
            ComprovacaoArtigo33V = comprovacaoArtigo33V;
            ComprovacaoArtigo35III = comprovacaoArtigo35III;
            ComprovacaoArtigo35V = comprovacaoArtigo35V;
            ComprovacaoArtigo35VI = comprovacaoArtigo35VI;
            MembroAdministracaoPublica = membroAdministracaoPublica;
            ComprovacaoArtigo34 = comprovacaoArtigo34;
            OrganizacaoSocialImpedida = organizacaoSocialImpedida;
            ExistenciaTermoCienciaNotificacao = existenciaTermoCienciaNotificacao;
        }

        public Ajuste Ajuste { get; private set; }
        public bool ComprovacaoArtigo33V { get; private set; }
        public bool ComprovacaoArtigo35III { get; private set; }
        public bool ComprovacaoArtigo35V { get; private set; }
        public bool ComprovacaoArtigo35VI { get; private set; }
        public bool MembroAdministracaoPublica { get; private set; }
        public bool ComprovacaoArtigo34 { get; private set; }
        public bool OrganizacaoSocialImpedida { get; private set; }
        public bool ExistenciaTermoCienciaNotificacao { get; private set; }
    }
}
