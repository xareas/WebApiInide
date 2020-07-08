using System;
using System.Collections.Generic;
using System.Text;
using Inide.WebServices.Persistence.Contracts;
using Inide.WebServices.Persistence.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.Services.Contracts
{
    public interface IEntidadService: IServiceBase,IEntidadRepository<Entidad>
    {
        //Aca definir tus propios metodos

      
    }
}
