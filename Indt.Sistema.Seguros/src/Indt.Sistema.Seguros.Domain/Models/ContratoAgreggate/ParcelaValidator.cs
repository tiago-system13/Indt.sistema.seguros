using FluentValidation;

namespace Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate
{
    public class ParcelaValidator : AbstractValidator<Parcela>
    {
        public ParcelaValidator() 
        {
            RuleFor(contrato => contrato.Numero)
              .Must(x => x > 0)
              .WithMessage("Informe um número de porposta válido.")
              .WithErrorCode("NUMERO_OBRIGATORIO");

            RuleFor(contrato => contrato.Data)
               .NotNull()
               .WithMessage("Informe data da parcela válido.")
               .WithErrorCode("DATAPARCELA_OBRIGATORIO");

            RuleFor(contrato => contrato.Valor)
               .Must(x => x > 0)
               .WithMessage("Informe um valor de porposta válido.")
               .WithErrorCode("VALOR_OBRIGATORIO");
        }
    }
}
