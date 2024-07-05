using MediatR;
using Microsoft.AspNetCore.Mvc;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.Application.Queries;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;

namespace TerceiroSetor.Api.Controllers
{
    [Route("api/organizacao-social")]
    [ApiController]
    public class OrganizacaoSocialController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IQueriesOrganizacaoSocial _queries;
        public OrganizacaoSocialController(INotificator notificator, IMediator mediator,
            IQueriesOrganizacaoSocial queries) : base(notificator) 
        {
            _mediator = mediator;
            _queries = queries;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(OrganizacaoSocialCommand viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _mediator.Send(viewModel);

            return CustomResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var organizacoes = await _queries.GetAllAsync();
            return CustomResponse(organizacoes);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var organizacao = await _queries.GetById(id);
            return CustomResponse(organizacao);
        }

        [HttpPut("informar-conselho")]
        public async Task<IActionResult> InformarConselho(ConselhoCommand viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _mediator.Send(viewModel);
            
            return CustomResponse();
        }

        [HttpPut("informar-responsavel")]
        public async Task<IActionResult> InformarResponsavel(ResponsavelCommand viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _mediator.Send(viewModel);

            return CustomResponse();
        }

        [HttpPut("encerrar-vigencia")]
        public async Task<IActionResult> EncerrarVigencia(EncerrarVigenciaConselhoCommand viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _mediator.Send(viewModel);

            return CustomResponse();
        }
    }
}
