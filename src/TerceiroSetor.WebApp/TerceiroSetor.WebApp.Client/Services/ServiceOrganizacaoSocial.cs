using Microsoft.Extensions.Options;
using System.Net;
using TerceiroSetor.DTOs;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;
using TerceiroSetor.DTOs.OrganizacoesSociais;
using TerceiroSetor.WebApp.Client.Settings;

namespace TerceiroSetor.WebApp.Client.Services
{
    public interface IServiceOrganizacaoSocial
    {
        Task<IEnumerable<OrganizacaoSocialDTO>> GetAllAsync();
        Task<OrganizacaoSocialDTO> GetByIdAsync(Guid id);
        Task<ResponseResult> AddAsync(OrganizacaoSocialCommand command);
        Task<ResponseResult> InformarResponsavelAsync(ResponsavelCommand command);
        Task<ResponseResult> InformarConselhoAsync(ConselhoCommand command);
        Task<ResponseResult> EncerrarVigenciaConselho(EncerrarVigenciaConselhoCommand command);

    }

    public class ServiceOrganizacaoSocial : ServiceBase, IServiceOrganizacaoSocial
    {
        private readonly HttpClient _httpClient;

        public ServiceOrganizacaoSocial(HttpClient httpClient, IOptions<ClientSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ApiEndpoint);
            _httpClient.DefaultRequestHeaders.Add("X-Tenant", "bora");
        }

        public async Task<ResponseResult> AddAsync(OrganizacaoSocialCommand command)
        {
            var content = GetContent(command);
            var response = await _httpClient.PostAsync("/api/organizacao-social", content);

            if(!HandleErrors(response)) return await GetJsonResponse<ResponseResult>(response);

            return ResponseOK();
        }

        public async Task<IEnumerable<OrganizacaoSocialDTO>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("/api/organizacao-social");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandleErrors(response);

            return await GetJsonResponse<IEnumerable<OrganizacaoSocialDTO>>(response);
        }

        public async Task<OrganizacaoSocialDTO> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/organizacao-social/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandleErrors(response);

            return await GetJsonResponse<OrganizacaoSocialDTO>(response);
        }

        public async Task<ResponseResult> InformarResponsavelAsync(ResponsavelCommand command)
        {
            var content = GetContent(command);
            var response = await _httpClient.PutAsync("/api/organizacao-social/informar-responsavel", content);

            if (!HandleErrors(response)) return await GetJsonResponse<ResponseResult>(response);

            return ResponseOK();
        }

        public async Task<ResponseResult>InformarConselhoAsync(ConselhoCommand command)
        {
            var content = GetContent(command);
            var response = await _httpClient.PutAsync("/api/organizacao-social/informar-conselho", content);

            if (!HandleErrors(response)) return await GetJsonResponse<ResponseResult>(response);

            return ResponseOK();
        }

        public async Task<ResponseResult> EncerrarVigenciaConselho(EncerrarVigenciaConselhoCommand command)
        {
            var content = GetContent(command);
            var response = await _httpClient.PutAsync("/api/organizacao-social/encerrar-vigencia", content);

            if (!HandleErrors(response)) return await GetJsonResponse<ResponseResult>(response);

            return ResponseOK();
        }
    }
}
