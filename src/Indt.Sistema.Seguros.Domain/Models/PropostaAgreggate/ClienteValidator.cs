using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator() {

            RuleFor(cliente => cliente.Documento)
                  .NotEmpty()
                  .WithMessage("Informe o documento do cliente.")
                  .WithErrorCode("DOCUMENTO_CLIENTE_OBRIGATORIO");

            RuleFor(cliente => cliente.Nome)
               .NotEmpty()
               .WithMessage("Informe o nome do cliente.")
               .WithErrorCode("NOME_CLIENTE_OBRIGATORIO");

            RuleFor(cliente => cliente.DataNescimento)
               .NotNull()
               .WithMessage("Informe data de nascimento válido.")
               .WithErrorCode("DTNASCIMENT_OBRIGATORIO");

           
        }
    }
}
