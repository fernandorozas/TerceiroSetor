using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.PlanosTrabalhos
{
    public class PlanoAplicacao : EntidadeBase
    {
        protected PlanoAplicacao() { }
        public PlanoAplicacao(CategoriaDespesa categoriaDespesa, int ano, int mes, decimal valor)
        {
            CategoriaDespesa = categoriaDespesa;
            Ano = ano;
            Mes = mes;
            Valor = valor;
        }

        public PlanoTrabalho PlanoTrabalho { get; private set; }
        public CategoriaDespesa CategoriaDespesa { get; private set; }
        public int Ano { get; private set; }
        public int Mes { get; private set; }
        public decimal Valor { get; private set; }
    }
}
