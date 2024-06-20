using TerceiroSetor.Domain.Entities.OrgaoPublico;
using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class Empenho : EntidadeBase
    {
        protected Empenho() { }
        public Empenho(int ano, string numero, DateTime data, string historico, 
            decimal valor, Ajuste ajuste, ClassificacaoDespesa classificacaoDespesa, 
            FonteRecurso fonteRecurso, OrdenadorDespesa ordenadorDespesa)
        {
            Ano = ano;
            Numero = numero;
            Data = data;
            Historico = historico;
            Valor = valor;
            Ajuste = ajuste;
            ClassificacaoDespesa = classificacaoDespesa;
            FonteRecurso = fonteRecurso;
            OrdenadorDespesa = ordenadorDespesa;
        }
        public int Ano { get; private set; }
        public string Numero { get; private set; }
        public DateTime Data { get; private set; }
        public string Historico { get; private set; }
        public decimal Valor { get; private set; }
        public Ajuste Ajuste { get; private set; }
        public ClassificacaoDespesa ClassificacaoDespesa { get; private set; }
        public FonteRecurso FonteRecurso { get; private set; }
        public OrdenadorDespesa OrdenadorDespesa { get; private set; }
        public ICollection<Repasse> Repasses { get; private set; }
    }
}
