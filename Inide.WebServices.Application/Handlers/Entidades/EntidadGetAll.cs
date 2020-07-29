using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Inide.WebServices.Application.Handlers.Base;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.Services.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Serenity.Services;

namespace Inide.WebServices.Application.Handlers.Entidades
{
    public class EntidadGetAll
    {
        public EventHandler<IEnumerable<EntidadResponse>> SelectedCompleted;
        public class Query : IRequest<IEnumerable<EntidadResponse>>
        {

        }

        public class Handler : HandlerBase<IEntidadService>,IRequestHandler<Query,IEnumerable<EntidadResponse>>
        {
            public Handler(IEntidadService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
                
            }

            public async Task<IEnumerable<EntidadResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var listRequest = new ListRequest(){};

                var data = await _service.ListAsync(_connection, listRequest);
                var entities = _mapper.Map<IEnumerable<EntidadResponse>>(data.Entities);
                
                return entities;
            }
      
        }

    } //public
} //fin namespace
