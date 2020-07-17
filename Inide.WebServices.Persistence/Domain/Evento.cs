using System;
using System.Collections.Generic;
using System.Text;
using Inide.WebServices.Persistence.Common;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;

namespace Inide.WebServices.Persistence.Domain
{
    [TwoLevelCached(new []{"Swap.Evento"}),ConnectionKey(ConfigPersistence.DefaultDb),TableName("[Swap].[Evento]")]
    public class Evento : Row,IIdRow, INameRow
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


        public Evento() : base(Fields)
        {
        }
        public IIdField IdField => Fields.KeyEvento;
        public StringField NameField => Fields.Nombre;

        public  class RowFields : RowFieldsBase
        {
            public Int32Field KeyEvento;

            public StringField Nombre;

           
        }

    }
}
