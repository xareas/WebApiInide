
namespace Inide.Inide.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Inide"), Module("Inide"), TableName("[Core].[Elemento]")]
    [DisplayName("Elemento"), InstanceName("Elemento")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class ElementoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Elemento"), Size(10), PrimaryKey, QuickSearch]
        public String KeyElemento
        {
            get { return Fields.KeyElemento[this]; }
            set { Fields.KeyElemento[this] = value; }
        }

        [DisplayName("Codigo"), Size(10), NotNull]
        public String Codigo
        {
            get { return Fields.Codigo[this]; }
            set { Fields.Codigo[this] = value; }
        }

        [DisplayName("Descripcion"), Size(200), NotNull]
        public String Descripcion
        {
            get { return Fields.Descripcion[this]; }
            set { Fields.Descripcion[this] = value; }
        }

        [DisplayName("Comentarios")]
        public String Comentarios
        {
            get { return Fields.Comentarios[this]; }
            set { Fields.Comentarios[this] = value; }
        }

        [DisplayName("Key Entidad"), NotNull, ForeignKey("[Core].[Entidad]", "KeyEntidad"), LeftJoin("jKeyEntidad"), TextualField("KeyEntidadDescripcion")]
        public Int64? KeyEntidad
        {
            get { return Fields.KeyEntidad[this]; }
            set { Fields.KeyEntidad[this] = value; }
        }

        [DisplayName("Codigo Padre"), Size(10), NotNull, ForeignKey("[Core].[Elemento]", "KeyElemento"), LeftJoin("jCodigoPadre"), TextualField("CodigoPadreCodigo")]
        public String CodigoPadre
        {
            get { return Fields.CodigoPadre[this]; }
            set { Fields.CodigoPadre[this] = value; }
        }

        [DisplayName("Key Entidad Descripcion"), Expression("jKeyEntidad.[Descripcion]")]
        public String KeyEntidadDescripcion
        {
            get { return Fields.KeyEntidadDescripcion[this]; }
            set { Fields.KeyEntidadDescripcion[this] = value; }
        }

        [DisplayName("Key Entidad Key Grupo Entidad"), Expression("jKeyEntidad.[KeyGrupoEntidad]")]
        public Int32? KeyEntidadKeyGrupoEntidad
        {
            get { return Fields.KeyEntidadKeyGrupoEntidad[this]; }
            set { Fields.KeyEntidadKeyGrupoEntidad[this] = value; }
        }

        [DisplayName("Key Entidad Comentarios"), Expression("jKeyEntidad.[Comentarios]")]
        public String KeyEntidadComentarios
        {
            get { return Fields.KeyEntidadComentarios[this]; }
            set { Fields.KeyEntidadComentarios[this] = value; }
        }

        [DisplayName("Codigo Padre Codigo"), Expression("jCodigoPadre.[Codigo]")]
        public String CodigoPadreCodigo
        {
            get { return Fields.CodigoPadreCodigo[this]; }
            set { Fields.CodigoPadreCodigo[this] = value; }
        }

        [DisplayName("Codigo Padre Descripcion"), Expression("jCodigoPadre.[Descripcion]")]
        public String CodigoPadreDescripcion
        {
            get { return Fields.CodigoPadreDescripcion[this]; }
            set { Fields.CodigoPadreDescripcion[this] = value; }
        }

        [DisplayName("Codigo Padre Comentarios"), Expression("jCodigoPadre.[Comentarios]")]
        public String CodigoPadreComentarios
        {
            get { return Fields.CodigoPadreComentarios[this]; }
            set { Fields.CodigoPadreComentarios[this] = value; }
        }

        [DisplayName("Codigo Padre Key Entidad"), Expression("jCodigoPadre.[KeyEntidad]")]
        public Int64? CodigoPadreKeyEntidad
        {
            get { return Fields.CodigoPadreKeyEntidad[this]; }
            set { Fields.CodigoPadreKeyEntidad[this] = value; }
        }

        [DisplayName("Codigo Padre"), Expression("jCodigoPadre.[CodigoPadre]")]
        public String CodigoPadre1
        {
            get { return Fields.CodigoPadre1[this]; }
            set { Fields.CodigoPadre1[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyElemento; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.KeyElemento; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ElementoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField KeyElemento;
            public StringField Codigo;
            public StringField Descripcion;
            public StringField Comentarios;
            public Int64Field KeyEntidad;
            public StringField CodigoPadre;

            public StringField KeyEntidadDescripcion;
            public Int32Field KeyEntidadKeyGrupoEntidad;
            public StringField KeyEntidadComentarios;

            public StringField CodigoPadreCodigo;
            public StringField CodigoPadreDescripcion;
            public StringField CodigoPadreComentarios;
            public Int64Field CodigoPadreKeyEntidad;
            public StringField CodigoPadre1;
        }
    }
}
