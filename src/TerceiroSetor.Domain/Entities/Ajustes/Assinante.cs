using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class Assinante : EntidadeBase
    {
        protected Assinante() { }
        public Assinante(Ajuste ajuste, TipoAssinante tipoAssinante, Pessoa pessoa, Cargo cargo)
        {
            Ajuste = ajuste;
            TipoAssinante = tipoAssinante;
            Pessoa = pessoa;
            Cargo = cargo;
        }

        public Ajuste Ajuste { get; private set; }
        public TipoAssinante TipoAssinante { get; set; }
        public Pessoa Pessoa { get; private set; }
        public Cargo Cargo { get; private set; }

    }
}
