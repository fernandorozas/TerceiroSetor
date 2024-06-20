namespace TerceiroSetor.DTOs.Shared
{
    public class PessoaDTO
    {
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string EmailPessoal { get; set; }
        public string EmailInstitucional { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
