using AutoMapper;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.DTOs.OrganizacoesSociais;

namespace TerceiroSetor.Application.Queries
{
    public interface IQueriesOrganizacaoSocial
    {
        public Task<IEnumerable<OrganizacaoSocialDTO>> GetAllAsync();
        public Task<OrganizacaoSocialDTO> GetById(Guid id);
    }

    public class QueriesOrganizacaoSocial : IQueriesOrganizacaoSocial
    {
        private readonly IRepositoryOrganizacaoSocial _repository;
        private readonly IMapper _mapper;

        public QueriesOrganizacaoSocial(IRepositoryOrganizacaoSocial repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganizacaoSocialDTO>> GetAllAsync()
        {
            var organizacoes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrganizacaoSocialDTO>>(organizacoes);
        }

        public async Task<OrganizacaoSocialDTO> GetById(Guid id)
        {
            var organizacao = await _repository.GetByIdAsync(id);
            return _mapper.Map<OrganizacaoSocialDTO>(organizacao);
        }
    }
}
