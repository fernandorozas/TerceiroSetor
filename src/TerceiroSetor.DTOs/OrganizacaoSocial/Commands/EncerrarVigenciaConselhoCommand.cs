using MediatR;
using TerceiroSetor.DTOs.OrganizacoesSociais;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class EncerrarVigenciaConselhoCommand : IRequest
    {
        public Guid OrganizacaoSocialId { get; set; }
        public TipoConselhoDTO TipoConselho { get; set; }
        public DateTime DataEncerramento { get; set; }
    }
}
