using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class CorpoDiretivoMembro
    {
        protected CorpoDiretivoMembro() { }
        public CorpoDiretivoMembro(Pessoa pessoa, DateTime inicioVigencia, DateTime finalVigencia)
        {
            Pessoa = pessoa;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
        }

        public CorpoDiretivo CorpoDiretivo { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
    }
}
