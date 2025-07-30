using FluentValidation;
using FluentValidation.Results;

namespace Indt.Sistema.Seguros.Domain.Models.Models.Shared
{
    public class CoreEntity
    {
        public Guid? Id { get; protected set; }  

        public DateTime DataDeCriacao { get; protected set; }

        public DateTime? DataDeAlteracao { get; protected set; }

        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public ValidationResult? ValidationResult { get; private set; }

        public CoreEntity() 
        {
            Id = Guid.NewGuid();
            DataDeCriacao = DateTime.Now;
        }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }       
    }
}
