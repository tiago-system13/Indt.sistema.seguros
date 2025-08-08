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
        public BemValidator() {

            RuleFor(bem => bem.AnoFabricacao)
                .NotEmpty()
                .WithMessage("Informe o ano de fabricação do bem.")
                .WithErrorCode("ANOFABRICACAO_BEM_OBRIGATORIO");

            RuleFor(bem => bem.Placa)
               .NotEmpty()
               .WithMessage("Informe a placa do bem.")
               .WithErrorCode("PLACA_BEM_OBRIGATORIO");

            RuleFor(bem => bem.Marca)
               .NotNull()
               .WithMessage("Informe a marca do bem.")
               .WithErrorCode("MARCA_BEM_OBRIGATORIO");

            RuleFor(bem => bem.Utilizacao)
              .NotEmpty()
              .WithMessage("Informe a utilização do bem.")
              .WithErrorCode("UTILIZACAO_BEM_OBRIGATORIO");

            RuleFor(bem => bem.Chassi)
               .NotEmpty()
               .WithMessage("Informe o chassi do bem.")
               .WithErrorCode("CHASSI_BEM_OBRIGATORIO");

            RuleFor(bem => bem.Cor)
               .NotEmpty()
               .WithMessage("Informe o cor do bem.")
               .WithErrorCode("COR_BEM_OBRIGATORIO");

            RuleFor(bem => bem.Categoria)
               .NotEmpty()
               .WithMessage("Informe a categoria do bem.")
               .WithErrorCode("CATEGORIA_BEM_OBRIGATORIO");
        }   
    }
}
