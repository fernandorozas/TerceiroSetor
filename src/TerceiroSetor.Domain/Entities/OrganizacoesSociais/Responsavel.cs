namespace TerceiroSetor.Domain.Entities.OrganizacoesSociais
{
    public class Responsavel 
    {
        public Responsavel() { }
        public OrganizacaoSocial OrganizacaoSocial { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public string EmailPessoal { get; private set; }
        public string EmailInstitucional { get; private set; }
        public VinculoTrabalhista VinculoTrabalhista { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public Guid UsuarioId { get; private set; }
        public void InformarUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;

    }
}
