
using Inide.WebServices.Persistence.Common;

namespace Inide.WebServices.Persistence.Domain
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [TableName("[Core].[Entidad]")]
    public sealed class Entidad : Row, IIdRow, INameRow
    {
        [DisplayName("No.Entidad"), Identity]
        public Int64? KeyEntidad
        {
            get => Fields.KeyEntidad[this];
            set => Fields.KeyEntidad[this] = value;
        }

        [DisplayName("Descripcion"), Size(150)]
        public String Descripcion
        {
            get => Fields.Descripcion[this];
            set => Fields.Descripcion[this] = value;
        }

        [DisplayName("Grupo Entidad"), MinSelectLevel(SelectLevel.Always) , ForeignKey("[Core].[GrupoEntidad]", "KeyGrupoEntidad"), LeftJoin("jKeyGrupoEntidad"), TextualField("GrupoEntidadDescipcion")]
        public Int32? KeyGrupoEntidad
        {
            get => Fields.KeyGrupoEntidad[this];
            set => Fields.KeyGrupoEntidad[this] = value;
        }

        [DisplayName("Comentarios"), Size(10)]
        public String Comentarios
        {
            get => Fields.Comentarios[this];
            set => Fields.Comentarios[this] = value;
        }

        [DisplayName("Descripcion"), Expression("jKeyGrupoEntidad.[Descipcion]"),MinSelectLevel(SelectLevel.Always) ]
        public String GrupoEntidadDescipcion
        {
            get => Fields.GrupoEntidadDescipcion[this];
            set => Fields.GrupoEntidadDescipcion[this] = value;
        }

        IIdField IIdRow.IdField => Fields.KeyEntidad;

        StringField INameRow.NameField => Fields.Descripcion;

        public static readonly RowFields Fields = new RowFields().Init();

        public Entidad(): base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field KeyEntidad;
            public StringField Descripcion;
            public Int32Field KeyGrupoEntidad;
            public StringField Comentarios;

            public StringField GrupoEntidadDescipcion;
        }
    }
}
