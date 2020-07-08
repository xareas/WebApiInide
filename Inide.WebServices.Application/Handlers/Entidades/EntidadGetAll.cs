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

namespace Inide.WebServices.Application.Handlers.Entidades
{
    public class EntidadGetAll
    {

        public class Query : IRequest<IEnumerable<EntidadResponse>>
        {
        }

        public class Handler : QueryBase<IEntidadService>,IRequestHandler<Query,IEnumerable<EntidadResponse>>
        {
            public Handler(IEntidadService service, IDbConnection connection, IMapper mapper) : base(service, connection, mapper)
            {
            }

            public async Task<IEnumerable<EntidadResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await _service.ListAsync(_connection, new ListRequest(){});
                var persons = _mapper.Map<IEnumerable<EntidadResponse>>(data.Entities);
                return persons;
            }
      
        }

    } //public
} //fin namespace
