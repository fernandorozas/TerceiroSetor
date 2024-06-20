using TerceiroSetor.Domain.Entities;

namespace TerceiroSetor.Application.Gateways
{
    public interface IIdentityService
    {
        Task<IEnumerable<IdentityUser>> GetUsers();
        Task<IdentityUser> GetUser(string email);
        Task<string> AddUser(IdentityUser user);
        Task<string> UpdateProfile(Guid userId, string imageUrl, string nomeExibicao);
        Task Logout(string refreshToken);
        Task AddRole(IdentityUser user, string role);
        Task AddTenant(IdentityUser user, string tenant);
    }
}
