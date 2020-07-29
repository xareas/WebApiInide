using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Inide.WebServices.Application.Handlers.Base;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Serenity.Data;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Eventos
{
    public class EventGetCategory
    {
        public class Query: IRequest<IEnumerable<Evento>>
        {
            public long Categoria { get; set; }
        }


        private class Handler: HandlerBase<IEventoService>,IRequestHandler<Query,IEnumerable<Evento>>
        {
            public Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
            }

            public async Task<IEnumerable<Evento>> Handle(Query request, CancellationToken cancellationToken)
            {
                var requestList = new ListRequest
                {
                    EqualityFilter = new Dictionary<string, object> {{"KeyEvento", request.Categoria}}
                };

               
               var responseList = await _service.ListAsync(_connection,requestList);
               return responseList.Entities.AsEnumerable();
            }
        }



    }
}
