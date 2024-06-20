using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class ConselhoMembro
    {
        protected ConselhoMembro() { }
        public ConselhoMembro(Pessoa pessoa, DateTime inicioVigencia, DateTime finalVigencia)
        {
            Pessoa = pessoa;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
        }
        public Conselho Conselho { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
    }
}
