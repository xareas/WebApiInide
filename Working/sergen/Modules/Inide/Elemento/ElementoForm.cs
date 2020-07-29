
namespace Inide.Inide.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Inide.Elemento")]
    [BasedOnRow(typeof(Entities.ElementoRow), CheckNames = true)]
    public class ElementoForm
    {
        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public String Comentarios { get; set; }
        public Int64 KeyEntidad { get; set; }
        public Int64 CodigoPadre { get; set; }
    }
}