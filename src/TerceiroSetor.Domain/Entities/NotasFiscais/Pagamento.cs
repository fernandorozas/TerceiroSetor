using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.NotasFiscais
{
    public class Pagamento: EntidadeBase
    {
        protected Pagamento() { }
        public Pagamento(DateTime dataPagamento, decimal valorPagamento, 
            string numeroTransacao, FonteRecurso fonteRecurso, ContaBancaria contaBancaria)
        {
            DataPagamento = dataPagamento;
            ValorPagamento = valorPagamento;
            NumeroTransacao = numeroTransacao;
            FonteRecurso = fonteRecurso;
            ContaBancaria = contaBancaria;
        }

        public NotaFiscal NotaFiscal { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public decimal ValorPagamento { get; private set; }
        public string NumeroTransacao { get; private set; }
        public FonteRecurso FonteRecurso { get; private set; }
        public ContaBancaria ContaBancaria { get; private set; }
    }
}
