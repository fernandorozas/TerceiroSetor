namespace TerceiroSetor.DTOs.OrganizacoesSociais
{
    public class ResponsavelDTO 
    {
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string EmailPessoal { get; set; }
        public string EmailInstitucional { get; set; }
        public Guid UsuarioId { get; set; }
        public VinculoTrabalhistaDTO VinculoTrabalhista { get; set;}
        public DateTime InicioVigencia { get; set;}
        public DateTime FinalVigencia { get; set;}
    }
}
