
namespace Inide.Inide.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Inide.Elemento")]
    [BasedOnRow(typeof(Entities.ElementoRow), CheckNames = true)]
    public class ElementoColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 KeyElemento { get; set; }
        [EditLink]
        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public String Comentarios { get; set; }
        public String KeyEntidadDescripcion { get; set; }
        public String CodigoPadreCodigo { get; set; }
    }
}