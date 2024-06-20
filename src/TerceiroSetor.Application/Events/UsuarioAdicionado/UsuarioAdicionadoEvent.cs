namespace TerceiroSetor.Application.Events.UsuarioAdicionado
{
    public class UsuarioAdicionadoEvent : Event
    {
        public UsuarioAdicionadoEvent(Guid organizacaoSocialId, string cpf, string email, string nome, TipoUsuario tipoUsuario)
        {
            OrganizacaoSocialId = organizacaoSocialId;
            Cpf = cpf;
            Email = email;
            Nome = nome;
            TipoUsuario = tipoUsuario;
        }

        public Guid OrganizacaoSocialId { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }

    public enum TipoUsuario
    {
        ResponsavelOrganizacaoSocial,
        ResponsavelOrgaoPublico,
        ResponsavelContratado
    }
}
