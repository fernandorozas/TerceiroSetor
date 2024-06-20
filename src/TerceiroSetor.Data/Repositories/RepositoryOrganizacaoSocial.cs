using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;

namespace TerceiroSetor.Data.Repositories
{
    public class RepositoryOrganizacaoSocial : Repository<OrganizacaoSocial>, IRepositoryOrganizacaoSocial
    {
        public RepositoryOrganizacaoSocial(TerceiroSetorDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AtualizarUsuarioResponsavel(Guid organizacaoSocialId, string cpf, Guid usuarioId)
        {
            var organizacaoSocial = await _dbSet.FindAsync(organizacaoSocialId);
            organizacaoSocial.Responsaveis.Where(x => x.Cpf == cpf).First().InformarUsuarioId(usuarioId);

            await UpdateAsync(organizacaoSocial);
        }
    }
}
