using FluentValidation.Results;

namespace Indt.Sistema.Seguros.Domain.Shared.Notifications
{
    public interface INotification
    {
        public IReadOnlyCollection<Notificacao> Notificacoes { get; }
        public bool ExisteNotificacoes { get; }
        void AddNotificacao(string codigo, string message);

        void AddNotificacao(Notificacao notification);

        void AddNotificacoes(IReadOnlyCollection<Notificacao> notifications);

        void AddNotificacoes(IList<Notificacao> notifications);

        void AddNotificacoes(ICollection<Notificacao> notifications);

        void AddNotificacoes(ValidationResult validationResult);
    }
}
