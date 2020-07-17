
namespace Inide.Inide.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Inide.Users")]
    [BasedOnRow(typeof(Entities.UsersRow), CheckNames = true)]
    public class UsersColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 UserId { get; set; }
        [EditLink]
        public String Username { get; set; }
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public String KeySexoSiglas { get; set; }
        public String Telefono { get; set; }
        public String Source { get; set; }
        public String PasswordHash { get; set; }
        public String PasswordSalt { get; set; }
        public DateTime LastDirectoryUpdate { get; set; }
        public String UserImage { get; set; }
        public String KeyDepartamentoDescripcion { get; set; }
        public String KeyMunicipioDescripcion { get; set; }
        public String KeyInstitucionSiglas { get; set; }
        public String Cargo { get; set; }
        public String Cedula { get; set; }
        public String Token { get; set; }
        public Boolean IsExternalService { get; set; }
        public Int32 KeyFilterRow { get; set; }
        public Int32 FilterValue { get; set; }
        public Int32 KeyTipoCuenta { get; set; }
        public String Comentarios { get; set; }
        public Int16 IsActive { get; set; }
        public DateTime InsertDate { get; set; }
        public Int32 InsertUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public Int32 UpdateUserId { get; set; }
    }
}