using TerceiroSetor.Domain.Entities.Shared;

namespace TerceiroSetor.Domain.Entities.Ajustes
{
    public class Repasse : EntidadeBase
    {
        protected Repasse() { }
        public Repasse(Empenho empenho, ContaBancaria contaBancaria, 
            DateTime dataPrevista, DateTime dataRepasse, decimal valorPrevisto, 
            decimal valorRepasse, string justificativaDiferenca, 
            TipoDocumentoBancario tipoDocumentoBancario,
            string descricaoOutros, string numeroDocumento, bool devolvido)
        {
            Empenho = empenho;
            ContaBancaria = contaBancaria;
            DataPrevista = dataPrevista;
            DataRepasse = dataRepasse;
            ValorPrevisto = valorPrevisto;
            ValorRepasse = valorRepasse;
            JustificativaDiferenca = justificativaDiferenca;
            TipoDocumentoBancario = tipoDocumentoBancario;
            DescricaoOutros = descricaoOutros;
            NumeroDocumento = numeroDocumento;
            Devolvido = devolvido;
        }

        public Empenho Empenho { get; private set; }
        public ContaBancaria ContaBancaria { get; private set; }
        public DateTime DataPrevista { get; private set; }
        public DateTime DataRepasse { get; private set; }
        public decimal ValorPrevisto { get; private set; }
        public decimal ValorRepasse { get; private set; }
        public string JustificativaDiferenca { get; private set; }
        public TipoDocumentoBancario TipoDocumentoBancario { get; private set; }
        public string DescricaoOutros { get; private set; }
        public string NumeroDocumento { get; private set; }
        public bool Devolvido { get; private set; }
    }
}
