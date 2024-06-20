namespace TerceiroSetor.DTOs.OrganizacoesSociais
{
    public class ConselhoDTO
    {
        public TipoConselhoDTO TipoConselho { get; set;}
        public DateTime InicioVigencia { get; set;}
        public DateTime FinalVigencia { get; set;}
        public ICollection<ConselhoMembroDTO> Membros { get; set;}
    }
}
