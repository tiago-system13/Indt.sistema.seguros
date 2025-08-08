using FluentValidation;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class CoberturaValidator: AbstractValidator<Cobertura>
    {
        public CoberturaValidator() {
            RuleFor(cobertura => cobertura.Franquia)
                .NotEmpty()
                .WithMessage("Informe a franquia da cobertura.")
                .WithErrorCode("FRANQUIA_COBERTURA_OBRIGATORIO");            

            RuleFor(cobertura => cobertura.LimiteIdenizacao)
               .NotNull()
               .WithMessage("Informe o limite de idenização.")
               .WithErrorCode("LIMITE_COBERTURA_OBRIGATORIO");

            RuleFor(cobertura => cobertura.Descricao)
              .NotEmpty()
              .WithMessage("Informe a descrição da cobertura.")
              .WithErrorCode("DESCRICAO_COBERTURA_OBRIGATORIO");

            RuleFor(cobertura => cobertura.Premio)
               .NotEmpty()
               .WithMessage("Informe o premio da cobertura.")
               .WithErrorCode("PREMIO_COBERTURA_OBRIGATORIO");         
        }
    }
}
