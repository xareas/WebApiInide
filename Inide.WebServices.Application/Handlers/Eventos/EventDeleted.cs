using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Inide.WebServices.Application.Factory;
using Inide.WebServices.Application.Handlers.Base;
using Microsoft.AspNetCore.Http;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Eventos
{
    public class EventDeleted
    {
        public class Query : IRequest<ApiResponse>
        {
            public long EntityId { get; set; }
        }
        private class Handler : CommandBase<IEventoService>, IRequestHandler<Query, ApiResponse>
        {
            public Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service,
                connection, mapper)
            {
            }
            
            public async Task<ApiResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                 
                    var unitWork = ServiceInjectFactory.CreateOfWork(_connection);
                    var requestDelete = new DeleteRequest() {EntityId = request.EntityId};
                    var result = await _service.DeleteAsync(unitWork, requestDelete);

                    if (result.Error == null)
                    {
                        
                        result.WasAlreadyDeleted = true;
                        return new ApiResponse($"Registro con codigo: {request.EntityId} fue borrado correctamente.",
                            result);
                    }

                    throw new ApiException("Registro no encontrado", StatusCodes.Status404NotFound);
                }
                catch (Exception)
                {
                    throw new ApiProblemDetailsException($"Registro con codigo: {request.EntityId} no encontrado.",
                        StatusCodes.Status404NotFound);
                }
            }
        }
        
    }
}
