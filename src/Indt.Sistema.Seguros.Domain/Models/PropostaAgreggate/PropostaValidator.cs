using FluentValidation;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using System;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class PropostaValidator :  AbstractValidator<Proposta>
    {
        public PropostaValidator() 
        {
            RuleFor(proposta => proposta.Numero)
               .Must(x => x > 0)
               .WithMessage("Informe um número de porposta válido.")
               .WithErrorCode("NUMERO_PROPOSTAINVALIDO");
         
            RuleFor(proposta => proposta.Valor)
               .Must(x => x > 0)
               .WithMessage("Informe um valor de porposta válido.")
               .WithErrorCode("VALOR_PROPOSTAINVALIDO");

            RuleFor(proposta => proposta.StatusProposta)
             .Must(x => Enum.IsDefined(typeof(StatusProposta), x))
             .WithMessage("Informe status de porposta válido.")
             .WithErrorCode("STATUS_PROPOSTAINVALIDO");

            RuleFor(proposta => proposta.TipoSeguro)
            .Must(x => Enum.IsDefined(typeof(TipoSeguro), x))
            .WithMessage("Informe tipo de seguro válido.")
            .WithErrorCode("TIPOSEGURO_PROPOSTAINVALIDO");

            RuleFor(x => x.Cliente).SetValidator(new ClienteValidator());
            RuleFor(x => x.Bem).SetValidator(new BemValidator());
            RuleFor(x => x.Cobertura).SetValidator(new CoberturaValidator());
        }
    }
}
