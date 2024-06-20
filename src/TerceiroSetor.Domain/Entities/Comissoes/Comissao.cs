namespace TerceiroSetor.Domain.Entities.Comissoes
{
    public class Comissao : EntidadeBase
    {
        public Comissao() { }
        public Comissao(TipoComissao tipoComissao, DateTime inicioVigencia, DateTime finalVigencia)
        {
            TipoComissao = tipoComissao;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
        }
        public TipoComissao TipoComissao { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public ICollection<ComissaoMembro> Membros { get; private set; }
    }
}
