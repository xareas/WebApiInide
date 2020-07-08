using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Event
{
    public class EventGetById
    {
        public class Query: IRequest<EventoResponse>
        {
            public long EntityId { get; set; }
        }

        public class Handler : QueryBase<IEventoService>,IRequestHandler<Query,EventoResponse>
        {
      
            public Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
            }
     
            public async Task<EventoResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var retrieveRequest = new RetrieveRequest() {EntityId = request.EntityId};
                    var evento = await _service.RetrieveAsync(_connection, retrieveRequest);
                
                    if (evento != null)
                        return _mapper.Map<EventoResponse>(evento.Entity);
                
                    throw new ApiException("Registro no encontrado",statusCode:StatusCodes.Status404NotFound);
                }
                catch (Exception e)
                {
                    throw new ApiProblemDetailsException($"Registro con codigo: {request.EntityId} no existe en la base de datos.-{e.Message}",StatusCodes.Status404NotFound);
                }
            
            }


      
        }

    }
}
