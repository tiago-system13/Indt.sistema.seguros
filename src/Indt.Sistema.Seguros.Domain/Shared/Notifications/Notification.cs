using FluentValidation.Results;

namespace Indt.Sistema.Seguros.Domain.Shared.Notifications
{
    internal class Notification : INotification
    {
        private readonly List<Notificacao> _notificacoes;
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;
        public bool ExisteNotificacoes => _notificacoes.Any();

        IReadOnlyCollection<Notificacao> INotification.Notificacoes { get => _notificacoes; }
        bool INotification.ExisteNotificacoes { get => _notificacoes.Any(); }

        public Notification()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void AddNotificacao(string codigo, string message)
        {
            _notificacoes.Add(new Notificacao(message, codigo));
        }

        public void AddNotificacao(Notificacao notification)
        {
            _notificacoes.Add(notification);
        }

        public void AddNotificacoes(IReadOnlyCollection<Notificacao> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void AddNotificacoes(IList<Notificacao> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void AddNotificacoes(ICollection<Notificacao> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void AddNotificacoes(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotificacao(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
