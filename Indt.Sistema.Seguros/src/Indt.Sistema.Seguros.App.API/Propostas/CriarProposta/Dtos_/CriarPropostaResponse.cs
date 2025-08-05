using Indt.Sistema.Seguros.App.API.Shared;

namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    public class CriarPropostaResponse : ResponseDto
    {
        public Guid PropostaId { get; set; }

        public CriarPropostaResponse(Guid propostaId)
        {
            PropostaId = propostaId;
        }
    }
}
