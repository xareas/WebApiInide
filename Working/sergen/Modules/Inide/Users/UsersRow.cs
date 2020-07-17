
namespace Inide.Inide.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Inide"), Module("Inide"), TableName("[Admon].[Users]")]
    [DisplayName("Users"), InstanceName("Users")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class UsersRow : Row, IIdRow, INameRow
    {
        [DisplayName("User Id"), Identity]
        public Int32? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Username"), Size(100), NotNull, QuickSearch]
        public String Username
        {
            get { return Fields.Username[this]; }
            set { Fields.Username[this] = value; }
        }

        [DisplayName("Display Name"), Size(100), NotNull]
        public String DisplayName
        {
            get { return Fields.DisplayName[this]; }
            set { Fields.DisplayName[this] = value; }
        }

        [DisplayName("Email"), Size(100)]
        public String Email
        {
            get { return Fields.Email[this]; }
            set { Fields.Email[this] = value; }
        }

        [DisplayName("Key Sexo"), ForeignKey("[MasterData].[Sexo]", "KeySexo"), LeftJoin("jKeySexo"), TextualField("KeySexoSiglas")]
        public Int32? KeySexo
        {
            get { return Fields.KeySexo[this]; }
            set { Fields.KeySexo[this] = value; }
        }

        [DisplayName("Telefono"), Size(10)]
        public String Telefono
        {
            get { return Fields.Telefono[this]; }
            set { Fields.Telefono[this] = value; }
        }

        [DisplayName("Source"), Size(4), NotNull]
        public String Source
        {
            get { return Fields.Source[this]; }
            set { Fields.Source[this] = value; }
        }

        [DisplayName("Password Hash"), Size(86), NotNull]
        public String PasswordHash
        {
            get { return Fields.PasswordHash[this]; }
            set { Fields.PasswordHash[this] = value; }
        }

        [DisplayName("Password Salt"), Size(10), NotNull]
        public String PasswordSalt
        {
            get { return Fields.PasswordSalt[this]; }
            set { Fields.PasswordSalt[this] = value; }
        }

        [DisplayName("Last Directory Update")]
        public DateTime? LastDirectoryUpdate
        {
            get { return Fields.LastDirectoryUpdate[this]; }
            set { Fields.LastDirectoryUpdate[this] = value; }
        }

        [DisplayName("User Image"), Size(100)]
        public String UserImage
        {
            get { return Fields.UserImage[this]; }
            set { Fields.UserImage[this] = value; }
        }

        [DisplayName("Key Departamento"), ForeignKey("[MasterData].[Departamento]", "KeyDepartamento"), LeftJoin("jKeyDepartamento"), TextualField("KeyDepartamentoDescripcion")]
        public Int32? KeyDepartamento
        {
            get { return Fields.KeyDepartamento[this]; }
            set { Fields.KeyDepartamento[this] = value; }
        }

        [DisplayName("Key Municipio"), ForeignKey("[MasterData].[Municipio]", "KeyMunicipio"), LeftJoin("jKeyMunicipio"), TextualField("KeyMunicipioDescripcion")]
        public Int32? KeyMunicipio
        {
            get { return Fields.KeyMunicipio[this]; }
            set { Fields.KeyMunicipio[this] = value; }
        }

        [DisplayName("Key Institucion"), ForeignKey("[MasterData].[Institucion]", "KeyInstitucion"), LeftJoin("jKeyInstitucion"), TextualField("KeyInstitucionSiglas")]
        public Int64? KeyInstitucion
        {
            get { return Fields.KeyInstitucion[this]; }
            set { Fields.KeyInstitucion[this] = value; }
        }

        [DisplayName("Cargo"), Size(150)]
        public String Cargo
        {
            get { return Fields.Cargo[this]; }
            set { Fields.Cargo[this] = value; }
        }

        [DisplayName("Cedula"), Size(16)]
        public String Cedula
        {
            get { return Fields.Cedula[this]; }
            set { Fields.Cedula[this] = value; }
        }

        [DisplayName("Token"), Size(500)]
        public String Token
        {
            get { return Fields.Token[this]; }
            set { Fields.Token[this] = value; }
        }

        [DisplayName("Is External Service"), NotNull]
        public Boolean? IsExternalService
        {
            get { return Fields.IsExternalService[this]; }
            set { Fields.IsExternalService[this] = value; }
        }

        [DisplayName("Key Filter Row")]
        public Int32? KeyFilterRow
        {
            get { return Fields.KeyFilterRow[this]; }
            set { Fields.KeyFilterRow[this] = value; }
        }

        [DisplayName("Filter Value")]
        public Int32? FilterValue
        {
            get { return Fields.FilterValue[this]; }
            set { Fields.FilterValue[this] = value; }
        }

        [DisplayName("Key Tipo Cuenta")]
        public Int32? KeyTipoCuenta
        {
            get { return Fields.KeyTipoCuenta[this]; }
            set { Fields.KeyTipoCuenta[this] = value; }
        }

        [DisplayName("Comentarios"), Size(255)]
        public String Comentarios
        {
            get { return Fields.Comentarios[this]; }
            set { Fields.Comentarios[this] = value; }
        }

        [DisplayName("Is Active"), NotNull]
        public Int16? IsActive
        {
            get { return Fields.IsActive[this]; }
            set { Fields.IsActive[this] = value; }
        }

        [DisplayName("Insert Date"), NotNull]
        public DateTime? InsertDate
        {
            get { return Fields.InsertDate[this]; }
            set { Fields.InsertDate[this] = value; }
        }

        [DisplayName("Insert User Id"), NotNull]
        public Int32? InsertUserId
        {
            get { return Fields.InsertUserId[this]; }
            set { Fields.InsertUserId[this] = value; }
        }

        [DisplayName("Update Date")]
        public DateTime? UpdateDate
        {
            get { return Fields.UpdateDate[this]; }
            set { Fields.UpdateDate[this] = value; }
        }

        [DisplayName("Update User Id")]
        public Int32? UpdateUserId
        {
            get { return Fields.UpdateUserId[this]; }
            set { Fields.UpdateUserId[this] = value; }
        }

        [DisplayName("Key Sexo Siglas"), Expression("jKeySexo.[Siglas]")]
        public String KeySexoSiglas
        {
            get { return Fields.KeySexoSiglas[this]; }
            set { Fields.KeySexoSiglas[this] = value; }
        }

        [DisplayName("Key Sexo Descripcion"), Expression("jKeySexo.[Descripcion]")]
        public String KeySexoDescripcion
        {
            get { return Fields.KeySexoDescripcion[this]; }
            set { Fields.KeySexoDescripcion[this] = value; }
        }

        [DisplayName("Key Sexo Comentarios"), Expression("jKeySexo.[Comentarios]")]
        public String KeySexoComentarios
        {
            get { return Fields.KeySexoComentarios[this]; }
            set { Fields.KeySexoComentarios[this] = value; }
        }

        [DisplayName("Key Departamento Descripcion"), Expression("jKeyDepartamento.[Descripcion]")]
        public String KeyDepartamentoDescripcion
        {
            get { return Fields.KeyDepartamentoDescripcion[this]; }
            set { Fields.KeyDepartamentoDescripcion[this] = value; }
        }

        [DisplayName("Key Departamento Codigo Inec"), Expression("jKeyDepartamento.[CodigoInec]")]
        public String KeyDepartamentoCodigoInec
        {
            get { return Fields.KeyDepartamentoCodigoInec[this]; }
            set { Fields.KeyDepartamentoCodigoInec[this] = value; }
        }

        [DisplayName("Key Departamento Key Region"), Expression("jKeyDepartamento.[KeyRegion]")]
        public Int32? KeyDepartamentoKeyRegion
        {
            get { return Fields.KeyDepartamentoKeyRegion[this]; }
            set { Fields.KeyDepartamentoKeyRegion[this] = value; }
        }

        [DisplayName("Key Departamento Key Delegacion"), Expression("jKeyDepartamento.[KeyDelegacion]")]
        public Int32? KeyDepartamentoKeyDelegacion
        {
            get { return Fields.KeyDepartamentoKeyDelegacion[this]; }
            set { Fields.KeyDepartamentoKeyDelegacion[this] = value; }
        }

        [DisplayName("Key Departamento Poblacion"), Expression("jKeyDepartamento.[Poblacion]")]
        public Int32? KeyDepartamentoPoblacion
        {
            get { return Fields.KeyDepartamentoPoblacion[this]; }
            set { Fields.KeyDepartamentoPoblacion[this] = value; }
        }

        [DisplayName("Key Departamento Superficie"), Expression("jKeyDepartamento.[Superficie]")]
        public Double? KeyDepartamentoSuperficie
        {
            get { return Fields.KeyDepartamentoSuperficie[this]; }
            set { Fields.KeyDepartamentoSuperficie[this] = value; }
        }

        [DisplayName("Key Departamento Comentarios"), Expression("jKeyDepartamento.[Comentarios]")]
        public String KeyDepartamentoComentarios
        {
            get { return Fields.KeyDepartamentoComentarios[this]; }
            set { Fields.KeyDepartamentoComentarios[this] = value; }
        }

        [DisplayName("Key Municipio Key Departamento"), Expression("jKeyMunicipio.[KeyDepartamento]")]
        public Int32? KeyMunicipioKeyDepartamento
        {
            get { return Fields.KeyMunicipioKeyDepartamento[this]; }
            set { Fields.KeyMunicipioKeyDepartamento[this] = value; }
        }

        [DisplayName("Key Municipio Key Delegacion"), Expression("jKeyMunicipio.[KeyDelegacion]")]
        public Int32? KeyMunicipioKeyDelegacion
        {
            get { return Fields.KeyMunicipioKeyDelegacion[this]; }
            set { Fields.KeyMunicipioKeyDelegacion[this] = value; }
        }

        [DisplayName("Key Municipio Key Oficina"), Expression("jKeyMunicipio.[KeyOficina]")]
        public Int32? KeyMunicipioKeyOficina
        {
            get { return Fields.KeyMunicipioKeyOficina[this]; }
            set { Fields.KeyMunicipioKeyOficina[this] = value; }
        }

        [DisplayName("Key Municipio Descripcion"), Expression("jKeyMunicipio.[Descripcion]")]
        public String KeyMunicipioDescripcion
        {
            get { return Fields.KeyMunicipioDescripcion[this]; }
            set { Fields.KeyMunicipioDescripcion[this] = value; }
        }

        [DisplayName("Key Municipio Cod Inec"), Expression("jKeyMunicipio.[CodInec]")]
        public String KeyMunicipioCodInec
        {
            get { return Fields.KeyMunicipioCodInec[this]; }
            set { Fields.KeyMunicipioCodInec[this] = value; }
        }

        [DisplayName("Key Municipio Poblacion"), Expression("jKeyMunicipio.[Poblacion]")]
        public Double? KeyMunicipioPoblacion
        {
            get { return Fields.KeyMunicipioPoblacion[this]; }
            set { Fields.KeyMunicipioPoblacion[this] = value; }
        }

        [DisplayName("Key Municipio Abreviatura"), Expression("jKeyMunicipio.[Abreviatura]")]
        public String KeyMunicipioAbreviatura
        {
            get { return Fields.KeyMunicipioAbreviatura[this]; }
            set { Fields.KeyMunicipioAbreviatura[this] = value; }
        }

        [DisplayName("Key Municipio Comentarios"), Expression("jKeyMunicipio.[Comentarios]")]
        public String KeyMunicipioComentarios
        {
            get { return Fields.KeyMunicipioComentarios[this]; }
            set { Fields.KeyMunicipioComentarios[this] = value; }
        }

        [DisplayName("Key Municipio Key Nucleo"), Expression("jKeyMunicipio.[KeyNucleo]")]
        public Int32? KeyMunicipioKeyNucleo
        {
            get { return Fields.KeyMunicipioKeyNucleo[this]; }
            set { Fields.KeyMunicipioKeyNucleo[this] = value; }
        }

        [DisplayName("Key Institucion Key Sector"), Expression("jKeyInstitucion.[KeySector]")]
        public Int64? KeyInstitucionKeySector
        {
            get { return Fields.KeyInstitucionKeySector[this]; }
            set { Fields.KeyInstitucionKeySector[this] = value; }
        }

        [DisplayName("Key Institucion Siglas"), Expression("jKeyInstitucion.[Siglas]")]
        public String KeyInstitucionSiglas
        {
            get { return Fields.KeyInstitucionSiglas[this]; }
            set { Fields.KeyInstitucionSiglas[this] = value; }
        }

        [DisplayName("Key Institucion Nombre"), Expression("jKeyInstitucion.[Nombre]")]
        public String KeyInstitucionNombre
        {
            get { return Fields.KeyInstitucionNombre[this]; }
            set { Fields.KeyInstitucionNombre[this] = value; }
        }

        [DisplayName("Key Institucion Key Tipo Institucion"), Expression("jKeyInstitucion.[KeyTipoInstitucion]")]
        public Int64? KeyInstitucionKeyTipoInstitucion
        {
            get { return Fields.KeyInstitucionKeyTipoInstitucion[this]; }
            set { Fields.KeyInstitucionKeyTipoInstitucion[this] = value; }
        }

        [DisplayName("Key Institucion Contacto"), Expression("jKeyInstitucion.[Contacto]")]
        public String KeyInstitucionContacto
        {
            get { return Fields.KeyInstitucionContacto[this]; }
            set { Fields.KeyInstitucionContacto[this] = value; }
        }

        [DisplayName("Key Institucion Telefono"), Expression("jKeyInstitucion.[Telefono]")]
        public String KeyInstitucionTelefono
        {
            get { return Fields.KeyInstitucionTelefono[this]; }
            set { Fields.KeyInstitucionTelefono[this] = value; }
        }

        [DisplayName("Key Institucion Email"), Expression("jKeyInstitucion.[Email]")]
        public String KeyInstitucionEmail
        {
            get { return Fields.KeyInstitucionEmail[this]; }
            set { Fields.KeyInstitucionEmail[this] = value; }
        }

        [DisplayName("Key Institucion Direccion"), Expression("jKeyInstitucion.[Direccion]")]
        public String KeyInstitucionDireccion
        {
            get { return Fields.KeyInstitucionDireccion[this]; }
            set { Fields.KeyInstitucionDireccion[this] = value; }
        }

        [DisplayName("Key Institucion Is Active"), Expression("jKeyInstitucion.[IsActive]")]
        public Boolean? KeyInstitucionIsActive
        {
            get { return Fields.KeyInstitucionIsActive[this]; }
            set { Fields.KeyInstitucionIsActive[this] = value; }
        }

        [DisplayName("Key Institucion Comentarios"), Expression("jKeyInstitucion.[Comentarios]")]
        public String KeyInstitucionComentarios
        {
            get { return Fields.KeyInstitucionComentarios[this]; }
            set { Fields.KeyInstitucionComentarios[this] = value; }
        }

        [DisplayName("Key Institucion User Created"), Expression("jKeyInstitucion.[UserCreated]")]
        public String KeyInstitucionUserCreated
        {
            get { return Fields.KeyInstitucionUserCreated[this]; }
            set { Fields.KeyInstitucionUserCreated[this] = value; }
        }

        [DisplayName("Key Institucion User Modified"), Expression("jKeyInstitucion.[UserModified]")]
        public String KeyInstitucionUserModified
        {
            get { return Fields.KeyInstitucionUserModified[this]; }
            set { Fields.KeyInstitucionUserModified[this] = value; }
        }

        [DisplayName("Key Institucion Date Created"), Expression("jKeyInstitucion.[DateCreated]")]
        public DateTime? KeyInstitucionDateCreated
        {
            get { return Fields.KeyInstitucionDateCreated[this]; }
            set { Fields.KeyInstitucionDateCreated[this] = value; }
        }

        [DisplayName("Key Institucion Date Modified"), Expression("jKeyInstitucion.[DateModified]")]
        public DateTime? KeyInstitucionDateModified
        {
            get { return Fields.KeyInstitucionDateModified[this]; }
            set { Fields.KeyInstitucionDateModified[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.UserId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Username; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public UsersRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field UserId;
            public StringField Username;
            public StringField DisplayName;
            public StringField Email;
            public Int32Field KeySexo;
            public StringField Telefono;
            public StringField Source;
            public StringField PasswordHash;
            public StringField PasswordSalt;
            public DateTimeField LastDirectoryUpdate;
            public StringField UserImage;
            public Int32Field KeyDepartamento;
            public Int32Field KeyMunicipio;
            public Int64Field KeyInstitucion;
            public StringField Cargo;
            public StringField Cedula;
            public StringField Token;
            public BooleanField IsExternalService;
            public Int32Field KeyFilterRow;
            public Int32Field FilterValue;
            public Int32Field KeyTipoCuenta;
            public StringField Comentarios;
            public Int16Field IsActive;
            public DateTimeField InsertDate;
            public Int32Field InsertUserId;
            public DateTimeField UpdateDate;
            public Int32Field UpdateUserId;

            public StringField KeySexoSiglas;
            public StringField KeySexoDescripcion;
            public StringField KeySexoComentarios;

            public StringField KeyDepartamentoDescripcion;
            public StringField KeyDepartamentoCodigoInec;
            public Int32Field KeyDepartamentoKeyRegion;
            public Int32Field KeyDepartamentoKeyDelegacion;
            public Int32Field KeyDepartamentoPoblacion;
            public DoubleField KeyDepartamentoSuperficie;
            public StringField KeyDepartamentoComentarios;

            public Int32Field KeyMunicipioKeyDepartamento;
            public Int32Field KeyMunicipioKeyDelegacion;
            public Int32Field KeyMunicipioKeyOficina;
            public StringField KeyMunicipioDescripcion;
            public StringField KeyMunicipioCodInec;
            public DoubleField KeyMunicipioPoblacion;
            public StringField KeyMunicipioAbreviatura;
            public StringField KeyMunicipioComentarios;
            public Int32Field KeyMunicipioKeyNucleo;

            public Int64Field KeyInstitucionKeySector;
            public StringField KeyInstitucionSiglas;
            public StringField KeyInstitucionNombre;
            public Int64Field KeyInstitucionKeyTipoInstitucion;
            public StringField KeyInstitucionContacto;
            public StringField KeyInstitucionTelefono;
            public StringField KeyInstitucionEmail;
            public StringField KeyInstitucionDireccion;
            public BooleanField KeyInstitucionIsActive;
            public StringField KeyInstitucionComentarios;
            public StringField KeyInstitucionUserCreated;
            public StringField KeyInstitucionUserModified;
            public DateTimeField KeyInstitucionDateCreated;
            public DateTimeField KeyInstitucionDateModified;
        }
    }
}
