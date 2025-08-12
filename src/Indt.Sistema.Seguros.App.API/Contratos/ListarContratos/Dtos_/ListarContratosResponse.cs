using Indt.Sistema.Seguros.App.API.Shared;

namespace Indt.Sistema.Seguros.App.API.Contratos.ListarContratos
{
    public class ListarContratosResponse  : ResponseDto
    {
        public List<ContratoDto> Contratos { get; set; }

        public int TotalContratos { get; set; }

        public decimal TotalPaginas { get; set; }


    }
}
