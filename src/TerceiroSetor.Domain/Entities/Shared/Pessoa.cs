using TerceiroSetor.Domain.ValueObjects;

namespace TerceiroSetor.Domain.Entities.Shared
{
    public class Pessoa
    {
        protected Pessoa() { }

        public Pessoa(string nomeCompleto, string cpf, string emailPessoal, string emailInstitucional, Endereco endereco)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            EmailPessoal = emailPessoal;
            EmailInstitucional = emailInstitucional;
            Endereco = endereco;
        }

        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public string EmailPessoal { get; private set; }
        public string EmailInstitucional { get; private set; }
        public Endereco Endereco { get; private set; }
        public Guid UsuarioId { get; private set; }
        public void InformarUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;
    }
}
