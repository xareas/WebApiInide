using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Inide.WebServices.Application.ResponseModels
{
    public class EntidadResponse
    {
        [JsonProperty(PropertyName = "Codigo")]
        public Int64 KeyEntidad { get; set; }
        public String Descripcion { get; set; }

        [JsonProperty(PropertyName = "CodGrupo")]
        public Int64 KeyGrupoEntidad { get; set; }
        
        [JsonProperty(PropertyName = "Grupo")]
        public String GrupoEntidadDescipcion { get; set; }
    }
}
