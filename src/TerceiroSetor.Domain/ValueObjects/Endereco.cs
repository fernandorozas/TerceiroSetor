namespace TerceiroSetor.Domain.ValueObjects
{
    public class Endereco
    {
        protected Endereco() { }
        public Endereco(string cep, string logradouro, string numero, string complemento, 
            string bairro, string cidade, string estado)
        {
            Cep = cep;
            Logradouro = logradouro;
            NumeroImovel = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string NumeroImovel { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}
