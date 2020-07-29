using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.Application.Events
{
    /// <summary>
    /// Firma del Evento
    /// </summary>
    public class TransaccionEvent: INotification
    {
        public string Message { get; }

        public TransaccionEvent(string message)
        {
            Message = message;
        }
    }

    /// <summary>
    /// Manajador del evento
    /// </summary>
    public class TransaccionEventHandler: INotificationHandler<TransaccionEvent>
    {
        private readonly ILogger<TransaccionEventHandler> _logger;

        public TransaccionEventHandler(ILogger<TransaccionEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(TransaccionEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() => _logger.LogInformation(notification.Message), cancellationToken);
        }
    }


}
