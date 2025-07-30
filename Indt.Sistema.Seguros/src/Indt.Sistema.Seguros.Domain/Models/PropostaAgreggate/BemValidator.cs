using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class BemValidator: AbstractValidator<Bem>
    {
        public BemValidator() { }   
    }
}
