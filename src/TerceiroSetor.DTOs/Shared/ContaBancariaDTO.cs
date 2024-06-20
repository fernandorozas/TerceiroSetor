namespace TerceiroSetor.DTOs.Shared
{
    public class ContaBancariaDTO
    {
        public BancoDTO Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public TipoContaDTO TipoConta { get; set; }
    }
}
