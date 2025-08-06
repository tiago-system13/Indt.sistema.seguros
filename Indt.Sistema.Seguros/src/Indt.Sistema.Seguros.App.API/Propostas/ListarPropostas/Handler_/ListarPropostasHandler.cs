using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indt.Sistema.Seguros.App.API.Propostas.ListarPropostas.Handler_
{
    public class ListarPropostasHandler
    {
        private readonly IPropostaRepository _propostaRepository;

        public ListarPropostasHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }


    }
}
