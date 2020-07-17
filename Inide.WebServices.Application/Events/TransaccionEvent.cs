using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Inide.WebServices.Application.Events
{
    /// <summary>
    /// Firma del Evento
    /// </summary>
    public class TransaccionEvent: INotification
    {
        public Guid TransaccionId { get; }

        public TransaccionEvent(Guid transaccionId)
        {
            TransaccionId = transaccionId;
        }
    }

    /// <summary>
    /// Manajador del evento
    /// </summary>
    public class TransaccionEventHandler: INotificationHandler<TransaccionEvent>
    {
        public async Task Handle(TransaccionEvent notification, CancellationToken cancellationToken)
        {
           
        }
    }


}
