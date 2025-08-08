using Indt.Sistema.Seguros.Domain.Shared.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Net;
using System.Text.Json;

namespace Indt.Sistema.Seguros.Commons.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotification _notificacaoContext;
        private readonly Serilog.ILogger _logger;
        public NotificationFilter(INotification notificacaoContext)
        {
            _notificacaoContext = notificacaoContext;
            _logger = Log.ForContext<NotificationFilter>(); 
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificacaoContext.ExisteNotificacoes)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonSerializer.Serialize(_notificacaoContext.Notificacoes);                
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }
}
