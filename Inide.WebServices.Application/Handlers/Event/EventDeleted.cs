using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Serenity.Data;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Event
{
    public class EventDeleted
    {
        public class Query : IRequest<ApiResponse>
        {
            public long EntityId { get; set; }
        }
        public class Handler : CommandBase<IEventoService>, IRequestHandler<Query, ApiResponse>
        {
            public Handler(IEventoService service, IDbConnection connection, IMapper mapper) : base(service,
                connection, mapper)
            {
            }
            
            public async Task<ApiResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var unitWork = new UnitOfWork(_connection);
                    unitWork.Commit();

                    var requestDelete = new DeleteRequest() {EntityId = request.EntityId};
                    var result = await _service.DeleteAsync(unitWork, requestDelete);

                    if (result.Error == null)
                    {
                        result.WasAlreadyDeleted = true;
                        return new ApiResponse($"Registro con codigo: {request.EntityId} fue borrado correctamente.",
                            result,
                            StatusCodes.Status200OK);
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
