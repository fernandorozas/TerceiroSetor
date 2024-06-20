namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class BemCedido : EntidadeBase
    {
        public BemCedido() {}
        public BemCedido(Ajuste ajuste, TipoBem tipoBem, string placaPatrimonial, 
            string descricao, DateTime dataCessao, decimal valor)
        {
            Ajuste = ajuste;
            TipoBem = tipoBem;
            PlacaPatrimonial = placaPatrimonial;
            Descricao = descricao;
            DataCessao = dataCessao;
            Valor = valor;
        }

        public Ajuste Ajuste { get; private set; }
        public TipoBem TipoBem { get; private set; }
        public string PlacaPatrimonial { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCessao { get; private set; }
        public decimal Valor { get; private set; }
    }
}
