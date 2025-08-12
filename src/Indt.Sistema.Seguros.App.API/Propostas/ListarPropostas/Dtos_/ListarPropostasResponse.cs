using Indt.Sistema.Seguros.App.API.Shared;

namespace Indt.Sistema.Seguros.App.API.Propostas.ListarPropostas
{
    public class ListarPropostasResponse : ResponseDto
    {
        public List<PropostasDto> Propostas { get; set; }

        public int TotalPropostas { get; set; }

        public decimal TotalPagina { get; set; }
    }
}
