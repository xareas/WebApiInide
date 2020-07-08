using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Event
{
    public class EventGetCategory
    {
        public class Query: IRequest<ListResponse<Evento>>
        {
            public long Categoria { get; set; }
        }


        public class Handler: QueryBase<IEventoService>,IRequestHandler<Query,ListResponse<Persistence.Domain.Evento>>
        {
            public Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
            }

            public async Task<ListResponse<Evento>> Handle(Query request, CancellationToken cancellationToken)
            {
                var requestList = new ListRequest
                {
                    EqualityFilter = new Dictionary<string, object> {{"KeyEvento", request.Categoria}}
                };

                return await _service.ListAsync(_connection,requestList);
            }
        }



    }
}
