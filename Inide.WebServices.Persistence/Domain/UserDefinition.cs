using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Persistence.Contracts;
using Serenity.Data;
using Serenity.Data.Mapping;


namespace Inide.WebServices.Persistence.Domain
{
    [TableName("[Admon].[Users]")]
    public class UserDefinition : Row, IIdRow, INameRow,IUserDefinition
    {
        [Identity]
        public int? UserId
        {
            get => Fields.UserId[this];
            set => Fields.UserId[this] = value;
        }

        [DisplayName("Username"), Size(100), NotNull, QuickSearch]
        public String UserName
        {
            get => Fields.UserName[this];
            set => Fields.UserName[this] = value;
        }

        [DisplayName("Display Name"), Size(100), NotNull]
        public String DisplayName
        {
            get => Fields.DisplayName[this];
            set => Fields.DisplayName[this] = value;
        }

        [DisplayName("Email"), Size(100)]
        public String Email
        {
            get => Fields.Email[this];
            set => Fields.Email[this] = value;
        }

        [DisplayName("Is Active"), NotNull]
        public Int16? IsActive
        {
            get => Fields.IsActive[this];
            set => Fields.IsActive[this] = value;
        }

        
        [DisplayName("Password Hash"), Size(86), NotNull]
        public String PasswordHash
        {
            get => Fields.PasswordHash[this];
            set => Fields.PasswordHash[this] = value;
        }

        [DisplayName("Password Salt"), Size(10), NotNull]
        public String PasswordSalt
        {
            get => Fields.PasswordSalt[this];
            set => Fields.PasswordSalt[this] = value;
        }

        public string RefreshToken
        {
            get => Fields.RefreshToken[this];
            set => Fields.RefreshToken[this] = value;
        }


        [DisplayName("Time Token") ]
        public DateTime? RefreshTokenExpiryTime
        {
            get => Fields.RefreshTokenExpiryTime[this];
            set => Fields.RefreshTokenExpiryTime[this] = value;
        }


        [DisplayName("Institucion")]
        public Int64? KeyInstitucion
        {
            get => Fields.KeyInstitucion[this];
            set => Fields.KeyInstitucion[this] = value;
        }




        public static readonly RowFields Fields = new RowFields().Init();
        
      
        public IIdField IdField => Fields.UserId;
        public StringField NameField => Fields.UserName;

        public UserDefinition() : base(Fields)
        {
        }

       
        public class RowFields : RowFieldsBase
        {
            public Int32Field UserId;
            public StringField UserName;
            public StringField DisplayName;
            public StringField Email;
            public StringField PasswordHash;
            public StringField PasswordSalt;
            public StringField RefreshToken; 
            public DateTimeField RefreshTokenExpiryTime;
            public Int16Field IsActive;

            //Filtrado
            public Int64Field KeyInstitucion;
        }

    }
}
