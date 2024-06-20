using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.OrgaoPublico
{
    public class OrdenadorDespesa : EntidadeBase
    {
        protected OrdenadorDespesa() { }
        public OrdenadorDespesa(OrgaoPublico orgaoPublico, Pessoa pessoa, 
            DateTime inicioVigencia, DateTime finalVigencia)
        {
            OrgaoPublico = orgaoPublico;
            Pessoa = pessoa;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
        }

        public OrgaoPublico OrgaoPublico { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
    }
}
