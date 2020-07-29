using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Inide.WebServices.Application.Factory;
using Inide.WebServices.Application.Handlers.Base;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Serenity.Data;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Eventos
{
    public class EventPut
    {
        public class Query: IRequest<ApiResponse>
        {
            public long EntityId { get; set;}
            public UpdateEventoRequest EntityUpdate { get; set; }
        }

        private class Handler: CommandBase<IEventoService>,IRequestHandler<Query,ApiResponse>
        {
            public   Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
            }
        
            public async Task<ApiResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var evento = _mapper.Map<Evento>(request.EntityUpdate);
                    evento.KeyEvento = Convert.ToInt32(request.EntityId);

                    var requestSave = new SaveRequest<Evento> {EntityId = request.EntityId,Entity = evento};
                    var unitWork = ServiceInjectFactory.CreateOfWork(_connection);
                
                    var result = await _service.UpdateAsync(unitWork, requestSave);
            
                    if (result.Error==null)
                    {
                        return new ApiResponse($"Registro con codigo: {request.EntityId} fue actualizado correctamente.", true);
                    }
                
                    throw new ApiProblemDetailsException($"Registro con codigo: {request.EntityId} no existe.", StatusCodes.Status404NotFound);
                

                }
                catch (Exception)
                {
                    throw new ApiProblemDetailsException($"Registro con codigo: {request.EntityId} no se pudo actualizar.", StatusCodes.Status404NotFound);
                }

            }
        }

    }
}
