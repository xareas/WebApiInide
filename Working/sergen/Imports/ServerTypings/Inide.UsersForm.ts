
namespace Inide.Inide {
    export class UsersForm extends Serenity.PrefixedContext {
        static formKey = 'Inide.Users';
    }

    export interface UsersForm {
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        KeySexo: Serenity.IntegerEditor;
        Telefono: Serenity.StringEditor;
        Source: Serenity.StringEditor;
        PasswordHash: Serenity.StringEditor;
        PasswordSalt: Serenity.StringEditor;
        LastDirectoryUpdate: Serenity.DateEditor;
        UserImage: Serenity.StringEditor;
        KeyDepartamento: Serenity.IntegerEditor;
        KeyMunicipio: Serenity.IntegerEditor;
        KeyInstitucion: Serenity.IntegerEditor;
        Cargo: Serenity.StringEditor;
        Cedula: Serenity.StringEditor;
        Token: Serenity.StringEditor;
        IsExternalService: Serenity.BooleanEditor;
        KeyFilterRow: Serenity.IntegerEditor;
        FilterValue: Serenity.IntegerEditor;
        KeyTipoCuenta: Serenity.IntegerEditor;
        Comentarios: Serenity.StringEditor;
        IsActive: Serenity.IntegerEditor;
        InsertDate: Serenity.DateEditor;
        InsertUserId: Serenity.IntegerEditor;
        UpdateDate: Serenity.DateEditor;
        UpdateUserId: Serenity.IntegerEditor;
    }

    [,
        ['Username', () => Serenity.StringEditor],
        ['DisplayName', () => Serenity.StringEditor],
        ['Email', () => Serenity.StringEditor],
        ['KeySexo', () => Serenity.IntegerEditor],
        ['Telefono', () => Serenity.StringEditor],
        ['Source', () => Serenity.StringEditor],
        ['PasswordHash', () => Serenity.StringEditor],
        ['PasswordSalt', () => Serenity.StringEditor],
        ['LastDirectoryUpdate', () => Serenity.DateEditor],
        ['UserImage', () => Serenity.StringEditor],
        ['KeyDepartamento', () => Serenity.IntegerEditor],
        ['KeyMunicipio', () => Serenity.IntegerEditor],
        ['KeyInstitucion', () => Serenity.IntegerEditor],
        ['Cargo', () => Serenity.StringEditor],
        ['Cedula', () => Serenity.StringEditor],
        ['Token', () => Serenity.StringEditor],
        ['IsExternalService', () => Serenity.BooleanEditor],
        ['KeyFilterRow', () => Serenity.IntegerEditor],
        ['FilterValue', () => Serenity.IntegerEditor],
        ['KeyTipoCuenta', () => Serenity.IntegerEditor],
        ['Comentarios', () => Serenity.StringEditor],
        ['IsActive', () => Serenity.IntegerEditor],
        ['InsertDate', () => Serenity.DateEditor],
        ['InsertUserId', () => Serenity.IntegerEditor],
        ['UpdateDate', () => Serenity.DateEditor],
        ['UpdateUserId', () => Serenity.IntegerEditor]
    ].forEach(x => Object.defineProperty(UsersForm.prototype, <string>x[0], {
        get: function () {
            return this.w(x[0], (x[1] as any)());
        },
        enumerable: true,
        configurable: true
    }));
}