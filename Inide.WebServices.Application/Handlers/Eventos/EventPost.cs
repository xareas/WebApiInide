using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Inide.WebServices.Application.Events;
using Inide.WebServices.Application.Factory;
using Inide.WebServices.Application.Handlers.Base;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Serenity.Data;
using Serenity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Application.Handlers.Eventos
{
    public class EventPost
    {
        public class Query: IRequest<ApiResponse>
        {
            public CreateEventoRequest NewEntity { get; set; }
        }

        private class Handler : CommandBase<IEventoService>,IRequestHandler<Query,ApiResponse>
        {
            public Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
            }

            public async Task<ApiResponse> Handle(Query request, CancellationToken cancellationToken)
            {

                
                var unitWork = ServiceInjectFactory.CreateOfWork(_connection);
                var evento = _mapper.Map<Evento>(request.NewEntity);

                var requestSave = new SaveRequest<Evento> {Entity = evento};
                var result = await _service.CreateAsync(unitWork, requestSave);

                return new ApiResponse("Registro Creado Correctamente.", result, StatusCodes.Status201Created);
            
            }

            
        }





    }
}
