using TerceiroSetor.Domain.ValueObjects;

namespace TerceiroSetor.Domain.Entities.Shared
{
    public class Credor : EntidadeBase
    {
        public Credor() {}

        public Credor(TipoCredor tipoCredor, string numeroInscricao, string razaoSocial, string nomeFantasia, 
            Endereco endereco, string telefone, string email)
        {
            TipoCredor = tipoCredor;
            NumeroInscricao = numeroInscricao;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }

        public TipoCredor TipoCredor { get; private set; }
        public string NumeroInscricao { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
    }
}
