using System;
using System.Collections.Generic;
using System.Text;
using Inide.WebServices.Persistence.Behaviours;
using Inide.WebServices.Persistence.Common;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;

namespace Inide.WebServices.Persistence.Domain
{
    [TwoLevelCached(new []{"Swap.Evento"}),TableName("[Swap].[Evento]")]
    public class Evento : Row,IIdRow, INameRow, IMultiTenancy
    {
        public static readonly RowFields Fields = new RowFields().Init();

        [Identity,SortOrder(1)]
        public Int32?  KeyEvento
        {
            get => Fields.KeyEvento[this];
            set => Fields.KeyEvento[this] = value;
        }

        [NotNull]
        public string  Nombre
        {
            get => Fields.Nombre[this];
            set => Fields.Nombre[this] = value;
        }
        
        public Int32? KeyInstitucion
        {
            get => Fields.KeyInstitucion[this];
            set => Fields.KeyInstitucion[this] = value;

        }


        public Evento() : base(Fields)
        {
        }
        public IIdField IdField => Fields.KeyEvento;
        public StringField NameField => Fields.Nombre;
        Int32Field IMultiTenancy.KeyInstitucion => Fields.KeyInstitucion; 
          
        public  class RowFields : RowFieldsBase
        {
            public Int32Field KeyEvento;

            public StringField Nombre;

            public Int32Field KeyInstitucion;

           
        }

     
    }
}
