using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class PropostaValidator :  AbstractValidator<Proposta>
    {
        public PropostaValidator() 
        {
            RuleFor(proposta => proposta.Numero)
               .Must(x => x > 0)
               .WithMessage("Informe um número de porposta válido.")
               .WithErrorCode("NUMERO_PROPOSTAVALIDO");

            RuleFor(proposta => proposta.Prazo)
               .Must(x => x > 0)
               .WithMessage("Informe prazo de porposta válido.")
               .WithErrorCode("PRAZO_PROPOSTAVALIDO");

            RuleFor(proposta => proposta.Valor)
               .Must(x => x > 0)
               .WithMessage("Informe um valor de porposta válido.")
               .WithErrorCode("VALOR_PROPOSTAVALIDO");

            RuleFor(x => x.Cliente).SetValidator(new ClienteValidator());
            RuleFor(x => x.Bem).SetValidator(new BemValidator());
            RuleFor(x => x.Cobertura).SetValidator(new CoberturaValidator());
        }
    }
}
