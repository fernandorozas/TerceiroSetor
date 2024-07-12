using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using TerceiroSetor.Api.Controllers;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.Application.Queries;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;
using TerceiroSetor.DTOs.OrganizacoesSociais;
using TerceiroSetor.DTOs.Shared.Commands;
using TerceiroSetor.Tests.Config;

namespace Tests.Service
{
    public class OrganizacaoSocialControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        
        private readonly OrganizacaoSocialController _controller;
        private readonly OrganizacaoSocialFixture _fixture;
        private readonly IRepositoryOrganizacaoSocial _repositoryOrganizacaoSocial;

        public OrganizacaoSocialControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/organizacao-social")]
        public async Task GetAll_OrganizacaoesSociais_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            client.DefaultRequestHeaders.Add("X-Tenant", "tenant");
            var response = await client.GetAsync(url);

            //Assert
            Assert.True(response.EnsureSuccessStatusCode().IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("api/organizacao-social", "2e295268-0ca2-4dc7-2833-08dc9556304d")]
        public async Task GetById_OrganizacaoesSociais_EndpointsReturnSuccessAndCorrectContentType(string baseUrl, string id)
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = $"{baseUrl}/{id}";

            // Act
            client.DefaultRequestHeaders.Add("X-Tenant", "tenant");
            var response = await client.GetAsync(url);
            // Assert
            Assert.True(response.EnsureSuccessStatusCode().IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("api/organizacao-social", "2e295268-0ca2-4dc7-2833-08dc9556304d")]
        public async Task GetById_OrganizacaoesSociais_ValidateCnpj_ReturnsExpectedCnpj(string baseUrl, string id)
        {
            var _client = _factory.CreateClient();
            // Arrange
            var url = $"{baseUrl}/{id}";

            // Act
            _client.DefaultRequestHeaders.Add("X-Tenant", "bora");
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            // Verificar se o Content-Type está presente antes de validar seu valor
            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var responseBody = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(responseBody);
            var cnpj = json["cnpj"]?.ToString();

            Assert.Equal("05030234000103", cnpj);
        }

        [Theory]
        [InlineData("api/organizacao-social", "2e295268-0ca2-4dc7-2833-08dc9556304d")]
        public async Task AlterarStatus_OrganizacaoSocial_EndpointsReturnSuccessAndCorrectData(string baseUrl, string id)
        {
            
            var _client = _factory.CreateClient();
            // Arrange
            var getUrl = $"{baseUrl}/{id}";
            var putUrl = $"{baseUrl}/alterar-status-organizacao-social";

            // Act - Paao 1: Pegar Status Atual
            _client.DefaultRequestHeaders.Add("X-Tenant", "bora");
            var getResponse = await _client.GetAsync(getUrl);

            // Assert Requisição com Sucesso
            getResponse.EnsureSuccessStatusCode();

            var getResponseBody = await getResponse.Content.ReadAsStringAsync();
            var getJson = JObject.Parse(getResponseBody);
            var currentStatus = getJson["ativo"]?.ToObject<bool>();
            var currentDataAtualizacao = getJson["dataAtualizacao"]?.ToObject<DateTime>();

            // Passo 2: Alterar o status
            var novoStatus = !currentStatus;

            var alterarStatusCommand = new AlterarStatusOrganizacaoSocialCommand
            {
                OrganizacaoSocialId = Guid.Parse(id),
                Ativo = (bool)novoStatus,
                DataAlteracao = DateTime.Now,
            };       
    
            var putResponse = await _client.PutAsJsonAsync(putUrl, alterarStatusCommand);

            // Assert PUT com sucesso
            putResponse.EnsureSuccessStatusCode();

            // Passo 3: updated com sucesso
            var getUpdatedResponse = await _client.GetAsync(getUrl);

            // Assert Novo Get com Sucesso
            getUpdatedResponse.EnsureSuccessStatusCode();

            var getUpdatedResponseBody = await getUpdatedResponse.Content.ReadAsStringAsync();
            var getUpdatedJson = JObject.Parse(getUpdatedResponseBody);
            var updatedStatus = getUpdatedJson["ativo"]?.ToObject<bool>();

            // Assert Conferindo se Status foi de fato alterado
            Assert.Equal(novoStatus, updatedStatus);
        }

        [Fact]
        public async Task Add_OrganizacaoSocial_ReturnsSuccess()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "api/organizacao-social";
            
            var novoCnpj = /*GerarStrCnpjValido();*/"08984491000164";

            var OrganizacaoSocialcommand = new OrganizacaoSocialCommand
            {
                Identificacao = new OrganizacaoSocialIdentificacaoCommand
                {
                    Nome = "Organização Social Teste Inclusão",
                    TipoOrganizacaoSocial = 1, // Exemplo de tipo
                    DataConstituicao = new DateTime(2020, 1, 1),
                    Telefone = "1234567890",
                    Cnpj = novoCnpj,
                    ArtigoReferencia = "Artigo X",
                    Finalidade = 1, // Exemplo de finalidade
                    FinalidadeResumida = "Uma organização social de exemplo."
                },
                Endereco = new EnderecoCommand
                {
                    Logradouro = "Rua Exemplo",
                    Numero = "123",
                    Complemento = "Apto 1",
                    Bairro = "Centro",
                    Cidade = "Cidade Exemplo",
                    Estado = "EX",
                    Cep = "12345000"
                }
            };

            // Act
            client.DefaultRequestHeaders.Add("X-Tenant", "bora");
            var response = await client.PostAsJsonAsync(url, OrganizacaoSocialcommand);

            // Assert
            response.EnsureSuccessStatusCode();

            // Verificar se a organização foi salva corretamente
            var getByCnpjUrl = $"{url}/cnpj/{novoCnpj}";
            var getResponse = await client.GetAsync(getByCnpjUrl);
            getResponse.EnsureSuccessStatusCode();

            var responseBody = await getResponse.Content.ReadAsStringAsync();
            var json = JObject.Parse(responseBody);
            var cnpj = json["cnpj"]?.ToString();
            var id = json["id"]?.ToString(); 

            Assert.Equal(novoCnpj, cnpj);
            
            /*
            // Delete the organization by ID
            var deleteUrl = $"{url}/{id}";
            var deleteResponse = await client.DeleteAsync(deleteUrl);
            deleteResponse.EnsureSuccessStatusCode();

            // Verificar se a organização foi deletada corretamente
            var getDeletedResponse = await client.GetAsync(getByCnpjUrl);
            Assert.False(getDeletedResponse.IsSuccessStatusCode);
            */

        }



    }
}
