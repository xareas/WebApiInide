using System;
using System.Collections.Generic;
using System.Text;

namespace Inide.WebServices.Application.Handlers.Entidades
{
    public interface IEntidadManager
    {
        public EntidadGetAll.Query GetAll { get; }
        public EntidadGrupo.Query GetGrupos { get; }
        public EntidadElementos.Query GetElements { get; }
    }

    public class EntidadManager : IEntidadManager
    {
        public EntidadGetAll.Query GetAll => new EntidadGetAll.Query();
        public EntidadGrupo.Query GetGrupos => new EntidadGrupo.Query();
        public EntidadElementos.Query GetElements => new EntidadElementos.Query();


    }




}
