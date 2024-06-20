namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class CorpoDiretivo
    {
        public CorpoDiretivo() { }
        public CorpoDiretivo(DateTime inicioVigencia, DateTime finalVigencia, 
            ICollection<CorpoDiretivoMembro> membros)
        {
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            Membros = membros;
        }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public ICollection<CorpoDiretivoMembro> Membros { get; private set; }
    }
}
