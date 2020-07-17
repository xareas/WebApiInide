
namespace Inide.Inide {
    export interface UsersRow {
        UserId?: number;
        Username?: string;
        DisplayName?: string;
        Email?: string;
        KeySexo?: number;
        Telefono?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        LastDirectoryUpdate?: string;
        UserImage?: string;
        KeyDepartamento?: number;
        KeyMunicipio?: number;
        KeyInstitucion?: number;
        Cargo?: string;
        Cedula?: string;
        Token?: string;
        IsExternalService?: boolean;
        KeyFilterRow?: number;
        FilterValue?: number;
        KeyTipoCuenta?: number;
        Comentarios?: string;
        IsActive?: number;
        InsertDate?: string;
        InsertUserId?: number;
        UpdateDate?: string;
        UpdateUserId?: number;
        KeySexoSiglas?: string;
        KeySexoDescripcion?: string;
        KeySexoComentarios?: string;
        KeyDepartamentoDescripcion?: string;
        KeyDepartamentoCodigoInec?: string;
        KeyDepartamentoKeyRegion?: number;
        KeyDepartamentoKeyDelegacion?: number;
        KeyDepartamentoPoblacion?: number;
        KeyDepartamentoSuperficie?: number;
        KeyDepartamentoComentarios?: string;
        KeyMunicipioKeyDepartamento?: number;
        KeyMunicipioKeyDelegacion?: number;
        KeyMunicipioKeyOficina?: number;
        KeyMunicipioDescripcion?: string;
        KeyMunicipioCodInec?: string;
        KeyMunicipioPoblacion?: number;
        KeyMunicipioAbreviatura?: string;
        KeyMunicipioComentarios?: string;
        KeyMunicipioKeyNucleo?: number;
        KeyInstitucionKeySector?: number;
        KeyInstitucionSiglas?: string;
        KeyInstitucionNombre?: string;
        KeyInstitucionKeyTipoInstitucion?: number;
        KeyInstitucionContacto?: string;
        KeyInstitucionTelefono?: string;
        KeyInstitucionEmail?: string;
        KeyInstitucionDireccion?: string;
        KeyInstitucionIsActive?: boolean;
        KeyInstitucionComentarios?: string;
        KeyInstitucionUserCreated?: string;
        KeyInstitucionUserModified?: string;
        KeyInstitucionDateCreated?: string;
        KeyInstitucionDateModified?: string;
    }

    export namespace UsersRow {
        export const idProperty = 'UserId';
        export const nameProperty = 'Username';
        export const localTextPrefix = 'Inide.Users';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export namespace Fields {
            export declare const UserId;
            export declare const Username;
            export declare const DisplayName;
            export declare const Email;
            export declare const KeySexo;
            export declare const Telefono;
            export declare const Source;
            export declare const PasswordHash;
            export declare const PasswordSalt;
            export declare const LastDirectoryUpdate;
            export declare const UserImage;
            export declare const KeyDepartamento;
            export declare const KeyMunicipio;
            export declare const KeyInstitucion;
            export declare const Cargo;
            export declare const Cedula;
            export declare const Token;
            export declare const IsExternalService;
            export declare const KeyFilterRow;
            export declare const FilterValue;
            export declare const KeyTipoCuenta;
            export declare const Comentarios;
            export declare const IsActive;
            export declare const InsertDate;
            export declare const InsertUserId;
            export declare const UpdateDate;
            export declare const UpdateUserId;
            export declare const KeySexoSiglas;
            export declare const KeySexoDescripcion;
            export declare const KeySexoComentarios;
            export declare const KeyDepartamentoDescripcion;
            export declare const KeyDepartamentoCodigoInec;
            export declare const KeyDepartamentoKeyRegion;
            export declare const KeyDepartamentoKeyDelegacion;
            export declare const KeyDepartamentoPoblacion;
            export declare const KeyDepartamentoSuperficie;
            export declare const KeyDepartamentoComentarios;
            export declare const KeyMunicipioKeyDepartamento;
            export declare const KeyMunicipioKeyDelegacion;
            export declare const KeyMunicipioKeyOficina;
            export declare const KeyMunicipioDescripcion;
            export declare const KeyMunicipioCodInec;
            export declare const KeyMunicipioPoblacion;
            export declare const KeyMunicipioAbreviatura;
            export declare const KeyMunicipioComentarios;
            export declare const KeyMunicipioKeyNucleo;
            export declare const KeyInstitucionKeySector;
            export declare const KeyInstitucionSiglas;
            export declare const KeyInstitucionNombre;
            export declare const KeyInstitucionKeyTipoInstitucion;
            export declare const KeyInstitucionContacto;
            export declare const KeyInstitucionTelefono;
            export declare const KeyInstitucionEmail;
            export declare const KeyInstitucionDireccion;
            export declare const KeyInstitucionIsActive;
            export declare const KeyInstitucionComentarios;
            export declare const KeyInstitucionUserCreated;
            export declare const KeyInstitucionUserModified;
            export declare const KeyInstitucionDateCreated;
            export declare const KeyInstitucionDateModified;
        }

        [
            'UserId',
            'Username',
            'DisplayName',
            'Email',
            'KeySexo',
            'Telefono',
            'Source',
            'PasswordHash',
            'PasswordSalt',
            'LastDirectoryUpdate',
            'UserImage',
            'KeyDepartamento',
            'KeyMunicipio',
            'KeyInstitucion',
            'Cargo',
            'Cedula',
            'Token',
            'IsExternalService',
            'KeyFilterRow',
            'FilterValue',
            'KeyTipoCuenta',
            'Comentarios',
            'IsActive',
            'InsertDate',
            'InsertUserId',
            'UpdateDate',
            'UpdateUserId',
            'KeySexoSiglas',
            'KeySexoDescripcion',
            'KeySexoComentarios',
            'KeyDepartamentoDescripcion',
            'KeyDepartamentoCodigoInec',
            'KeyDepartamentoKeyRegion',
            'KeyDepartamentoKeyDelegacion',
            'KeyDepartamentoPoblacion',
            'KeyDepartamentoSuperficie',
            'KeyDepartamentoComentarios',
            'KeyMunicipioKeyDepartamento',
            'KeyMunicipioKeyDelegacion',
            'KeyMunicipioKeyOficina',
            'KeyMunicipioDescripcion',
            'KeyMunicipioCodInec',
            'KeyMunicipioPoblacion',
            'KeyMunicipioAbreviatura',
            'KeyMunicipioComentarios',
            'KeyMunicipioKeyNucleo',
            'KeyInstitucionKeySector',
            'KeyInstitucionSiglas',
            'KeyInstitucionNombre',
            'KeyInstitucionKeyTipoInstitucion',
            'KeyInstitucionContacto',
            'KeyInstitucionTelefono',
            'KeyInstitucionEmail',
            'KeyInstitucionDireccion',
            'KeyInstitucionIsActive',
            'KeyInstitucionComentarios',
            'KeyInstitucionUserCreated',
            'KeyInstitucionUserModified',
            'KeyInstitucionDateCreated',
            'KeyInstitucionDateModified'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}