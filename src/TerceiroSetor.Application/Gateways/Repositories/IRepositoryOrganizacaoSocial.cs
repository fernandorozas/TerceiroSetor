using TerceiroSetor.Domain.Entities.OrganizacoesSociais;

namespace TerceiroSetor.Application.Gateways.Repositories
{
    public interface IRepositoryOrganizacaoSocial: IRepository<OrganizacaoSocial>
    {
        Task AtualizarUsuarioResponsavel(Guid organizacaoSocialId, string cpf, Guid usuarioId);
        Task<OrganizacaoSocial> GetByCnpjAsync(string cnpj);


    }
}
