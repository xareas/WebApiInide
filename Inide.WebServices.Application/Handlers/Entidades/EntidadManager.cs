using System;
using System.Collections.Generic;
using System.Text;

namespace Inide.WebServices.Application.Handlers.Entidades
{
    public interface IEntidadManager
    {
        public EntidadGetAll.Query GetAll { get; }
    }

    public class EntidadManager : IEntidadManager
    {
        public EntidadGetAll.Query GetAll => new EntidadGetAll.Query();
    }
}
