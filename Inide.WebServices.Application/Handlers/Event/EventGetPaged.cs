using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Event
{
    public class EventGetPaged
    {
        public class Query: IRequest<IEnumerable<EventoResponse>>
        {
            public UrlQueryParameters Parameters { get; set; }
        }

        public class Handler: QueryBase<IEventoService>,IRequestHandler<Query,IEnumerable<EventoResponse>>
        {
            private readonly IHttpContextAccessor _context;
            public Handler(IHttpContextAccessor context,IEventoService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
                _context = context;
            }

            public async Task<IEnumerable<EventoResponse>> Handle(Query request, CancellationToken cancellationToken)
            {

               
                var pagedRequest = new ListRequest() { Take = request.Parameters.PageSize, Skip = request.Parameters.Skip};
            
                var data = await _service.ListAsync(_connection, pagedRequest);

                var persons = _mapper.Map<IEnumerable<EventoResponse>>(data.Entities);
                if(request.Parameters.IncludeCount)
                 _context.HttpContext.Response.Headers.Add("Inide-Pagination", JsonSerializer.Serialize(data.TotalCount));
                
                return persons;

            }

       
        }
    }
}
