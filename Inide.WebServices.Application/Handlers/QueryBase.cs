using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AutoMapper;
using Inide.WebServices.Persistence.Repository;
using Inide.WebServices.Services;

namespace Inide.WebServices.Application.Handlers
{
    public abstract class QueryBase<T>
    {
        protected readonly T _service;
        protected readonly IMapper _mapper;
        protected readonly IDbConnection _connection;

        protected QueryBase(T service,IDbConnection connection, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _connection = connection;  
        }

    }
}
