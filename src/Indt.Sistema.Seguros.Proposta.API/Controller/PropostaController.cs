using Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta;
using Indt.Sistema.Seguros.App.API.Propostas.CriarProposta;
using Indt.Sistema.Seguros.App.API.Propostas.ListarPropostas;
using Indt.Sistema.Seguros.Domain.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Indt.Sistema.Seguros.Proposta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public PropostaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Criar proposta.
        /// </summary>
        /// <returns>Proposta cadastrada</returns>
        /// <response code="200">Retorna proposta cadastrado</response>
        /// <response code="400">Proposta Inválido</response>
        [HttpPost]
        [ProducesResponseType(typeof(CriarPropostaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Realiza cadastro de propostas")]
        public async ValueTask<IActionResult> Inserir([FromBody] CriarPropostaRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        /// <summary>
        /// Atualizar status proposta.
        /// </summary>
        /// <returns>Atualizar status proposta cadastrada</returns>
        /// <response code="200">Id proposta com status atualizado</response>
        /// <response code="400">Proposta Inválido</response>
        [HttpPatch]
        [ProducesResponseType(typeof(AlterarStatusPropostaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Alterar status proposta")]
        public async ValueTask<IActionResult> AlterarSatusProposta([FromBody] AlterarStatusPropostaRequest request, CancellationToken cancellationToken)
        {
            return Accepted("", await _mediator.Send(request, cancellationToken));
        }

        /// <summary>
        /// Listar propostas.
        /// </summary>
        /// <param name="cancellationToken">
        /// <returns>Listyagem de propostas cadastradas</returns>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpGet]
        [ProducesResponseType(typeof(ListarPropostasResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Listar propostas")]
        public async ValueTask<IActionResult> AlterarSatusProposta
        (
            [FromQuery] int numero,
            [FromQuery] StatusProposta statusPorposta,
            [FromQuery] DateTimeOffset dataIncial,
            [FromQuery] DateTimeOffset dataFinal,
            [FromQuery] int pagina = 1,
            [FromQuery] int itensPaginas= 50,
            CancellationToken cancellationToken = default
        )
        {
            var request = new ListarPropostasRequest()
            {
                StatusProposta = statusPorposta,
                Numero = numero,
                DataInicial = dataIncial,
                DataFim = dataFinal,
                Pagina = pagina,
                ItensPorPagina = itensPaginas
            };

            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}