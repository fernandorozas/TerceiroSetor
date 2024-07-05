using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceiroSetor.DTOs.OrganizacoesSociais;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class EncerrarVigenciaResponsavelCommand : IRequest
    {
        public Guid OrganizacaoSocialId { get; set; }
        public VinculoTrabalhistaDTO VinculoTrabalhista { get; set; }
        public DateTime DataEncerramento { get; set; }
    }
}

