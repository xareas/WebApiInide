using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Event
{
    public class EventGetAll
    {
        public class Query : IRequest<IEnumerable<EventoResponse>>
        {
        }

        public class Handler : QueryBase<IEventoService>,IRequestHandler<Query,IEnumerable<EventoResponse>>
        {
            public Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
            }

            public async Task<IEnumerable<EventoResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await _service.ListAsync(_connection, new ListRequest(){});
                var persons = _mapper.Map<IEnumerable<EventoResponse>>(data.Entities);
                return persons;
            }

       
        }


    }
}
