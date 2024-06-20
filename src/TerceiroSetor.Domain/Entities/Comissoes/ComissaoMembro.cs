using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.Comissoes
{
    public class ComissaoMembro : EntidadeBase
    {
        protected ComissaoMembro() { }
        public ComissaoMembro(Comissao comissao, Pessoa pessoa, DateTime inicioVigencia, 
            DateTime finalVigencia)
        {
            Comissao = comissao;
            Pessoa = pessoa;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
        }
        public Comissao Comissao { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
    }
}
