namespace TerceiroSetor.DTOs.OrganizacoesSociais
{
    public class CorpoDiretivoDTO
    {
        public DateTime InicioVigencia { get; set;}
        public DateTime FinalVigencia { get; set;}
        public ICollection<CorpoDiretivoMembroDTO> Membros { get; set;}
    }
}
