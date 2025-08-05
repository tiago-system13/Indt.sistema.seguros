using Indt.Sistema.Seguros.App.API.Shared;

namespace Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta
{
    public class AlterarStatusPropostaResponse : ResponseDto
    {
       public Guid PropostaId { get; set; }

        public AlterarStatusPropostaResponse(Guid propostaId)
        {
            PropostaId = propostaId;
        }
    }
}
