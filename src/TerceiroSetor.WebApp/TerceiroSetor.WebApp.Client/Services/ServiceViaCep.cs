using Newtonsoft.Json;

namespace TerceiroSetor.WebApp.Client.Services
{
    public interface IServiceViaCep
    {
        Task<EnderecoViaCep> ObterEndereco(string cep);
    }
    public class ServiceViaCep : IServiceViaCep
    {
        private readonly ILogger<ServiceViaCep> _logger;
        public ServiceViaCep(ILogger<ServiceViaCep> logger)
        {
            _logger = logger;
        }

        public async Task<EnderecoViaCep> ObterEndereco(string cep)
        {
            try
            {
                if (cep.Length < 8) return new EnderecoViaCep();

                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
                var response = await httpClient.GetAsync($"{cep}/json");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var endereco = JsonConvert.DeserializeObject<EnderecoViaCep>(json);
                return endereco ?? new EnderecoViaCep();

            }
            catch
            {
                _logger.LogWarning($"Cep informado não encontrado: {cep} ");
                return new EnderecoViaCep();
            }
        }
    }
    public class EnderecoViaCep
    {
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Localidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Ibge { get; set; } = string.Empty;
    }


}
