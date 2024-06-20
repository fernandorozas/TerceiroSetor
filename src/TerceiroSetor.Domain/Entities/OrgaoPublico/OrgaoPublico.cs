using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.OrgaoPublico
{
    public class OrgaoPublico : EntidadeBase
    {
        protected OrgaoPublico() { }
        public OrgaoPublico(int codigoMunicipio, int codigoEntidade, string nomeEntidade)
        {
            CodigoMunicipio = codigoMunicipio;
            CodigoEntidade = codigoEntidade;
            NomeEntidade = nomeEntidade;
        }

        public int CodigoMunicipio { get; private set; }
        public int CodigoEntidade { get; private set; }
        public string NomeEntidade { get; private set; }
        public ICollection<OrdenadorDespesa> Ordenadores { get; private set; }
        public ICollection<ContaBancaria> ContasBancarias { get; private set; }
    }
}
