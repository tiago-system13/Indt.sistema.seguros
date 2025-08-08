using FluentValidation;

namespace Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate
{
    public class ContratoValidator : AbstractValidator<Contrato>
    {
        public ContratoValidator() {
            
            RuleFor(contrato => contrato.Numero)
               .Must(x => x > 0)
               .WithMessage("Informe um número de porposta válido.")
               .WithErrorCode("NUMERO_OBRIGATORIO");

            RuleFor(contrato => contrato.Prazo)
               .Must(x => x > 0)
               .WithMessage("Informe prazo de porposta válido.")
               .WithErrorCode("PRAZO_OBRIGATORIO");

            RuleFor(contrato => contrato.Valor)
               .Must(x => x > 0)
               .WithMessage("Informe um valor de porposta válido.")
               .WithErrorCode("VALOR_OBRIGATORIO");

            RuleFor(contrato => contrato.DataInicial)
              .NotNull()
              .WithMessage("Informe a data inicial do contrato válido.")
              .WithErrorCode("DATAINICIAL_OBRIGATORIO");

            RuleFor(contrato => contrato.DataFinal)
              .NotNull()
              .WithMessage("Informe a data final do contrato válido.")
              .WithErrorCode("DATAINICIAL_OBRIGATORIO");
            
            RuleForEach(x => x.Parcelas).SetValidator(new ParcelaValidator());
        }
    }
}
