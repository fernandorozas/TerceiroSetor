using TerceiroSetor.Domain.Entities.Publicacoes;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.PlanosTrabalhos
{
    public class PlanoTrabalho: EntidadeBase
    {
        protected PlanoTrabalho() { }
        public PlanoTrabalho(DateTime inicioVigencia, DateTime finalVigencia, string projeto, string objeto, string justificativa)
        {
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            Projeto = projeto;
            Objeto = objeto;
            Justificativa = justificativa;
        }

        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public string Projeto { get; private set; }
        public string Objeto { get; private set; }
        public string Justificativa { get; private set; }
        public ICollection<PlanoAplicacao> PlanoAplicacao { get; private set; }
        public ICollection<CronogramaDesembolso> CronogramaDesembolso { get; private set; }
        public ICollection<PlanoMetas> Metas { get; private set; }
        public ICollection<Arquivo> Arquivos { get; private set; }
        public ICollection<Publicacao> Publicacoes { get; private set; }
    }
}
