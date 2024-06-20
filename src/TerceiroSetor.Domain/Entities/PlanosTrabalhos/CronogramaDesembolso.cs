namespace TerceiroSetor.Domain.Entities.PlanosTrabalhos
{
    public class CronogramaDesembolso: EntidadeBase
    {
        protected CronogramaDesembolso() { }
        public CronogramaDesembolso(int ano, int mes, decimal valor)
        {
            Ano = ano;
            Mes = mes;
            Valor = valor;
        }

        public PlanoTrabalho PlanoTrabalho { get; private set; }
        public int Ano { get; private set; }
        public int Mes { get; private set; }
        public decimal Valor { get; private set; }
    }
}
