using Indt.Sistema.Seguros.App.API.Contratos.ListarContratos;
using Indt.Sistema.Seguros.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Indt.Sistema.Seguros.Contratos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public ContratoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Listar contratos.
        /// </summary>
        /// <param name="cancellationToken">
        /// <returns>Listagem de contratos</returns>        
        [HttpGet]
        [ProducesResponseType(typeof(ListarContratosResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Listar contratos")]
        public async ValueTask<IActionResult> ListarContratos
        (
            [FromQuery] int numero,     
            [FromQuery] DateTimeOffset dataIncial,
            [FromQuery] DateTimeOffset dataFinal,
            [FromQuery] int pagina = 1,
            [FromQuery] int itensPaginas= 50,
            CancellationToken cancellationToken = default
        )
        {
            var request = new ListarContratosRequest()
            {                
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