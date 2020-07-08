using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Serenity.Data;
using Serenity.Services;
using Microsoft.AspNetCore.Http;

namespace Inide.WebServices.Application.Handlers.Event
{
    public class EventPost
    {
        public class Query: IRequest<ApiResponse>
        {
            public CreateEventoRequest NewEntity { get; set; }
        }

        public class Handler : CommandBase<IEventoService>,IRequestHandler<Query,ApiResponse>
        {
            public Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
            }

            public async Task<ApiResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var  unitWork = new UnitOfWork(_connection);
                unitWork.Commit();

                var evento = _mapper.Map<Persistence.Domain.Evento>(request.NewEntity);

                var requestSave = new SaveRequest<Persistence.Domain.Evento> {Entity = evento};
                var result = await _service.CreateAsync(unitWork, requestSave);

                return new ApiResponse("Registro Creado Correctamente.", result, StatusCodes.Status201Created);
            
            }
        }





    }
}
