using System;
using System.Collections.Generic;
using System.Text;

namespace Inide.WebServices.Application.ResponseModels
{
    public class EntidadResponse
    {
        public Int64 KeyEntidad { get; set; }
        public String Descripcion { get; set; }
        public String GrupoEntidadDescipcion { get; set; }
        public String Comentarios { get; set; }
    }
}
