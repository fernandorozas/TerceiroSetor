namespace TerceiroSetor.Domain.Entities.Shared
{
    public class ContaBancaria
    {
        protected ContaBancaria() {}

        public ContaBancaria(Banco banco, string agencia, string contaCorrente, TipoConta tipoConta)
        {
            Banco = banco;
            Agencia = agencia;
            ContaCorrente = contaCorrente;
            TipoConta = tipoConta;
        }

        public Banco Banco { get; private set; }
        public string Agencia { get; private set; }
        public string ContaCorrente { get; private set; }
        public TipoConta TipoConta { get; private set; }
    }
}
