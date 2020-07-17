
namespace Inide.Inide {
    export interface ElementoRow {
        KeyElemento?: string;
        Codigo?: string;
        Descripcion?: string;
        Comentarios?: string;
        KeyEntidad?: number;
        CodigoPadre?: string;
        KeyEntidadDescripcion?: string;
        KeyEntidadKeyGrupoEntidad?: number;
        KeyEntidadComentarios?: string;
        CodigoPadreCodigo?: string;
        CodigoPadreDescripcion?: string;
        CodigoPadreComentarios?: string;
        CodigoPadreKeyEntidad?: number;
        CodigoPadre1?: string;
    }

    export namespace ElementoRow {
        export const idProperty = 'KeyElemento';
        export const nameProperty = 'KeyElemento';
        export const localTextPrefix = 'Inide.Elemento';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export namespace Fields {
            export declare const KeyElemento;
            export declare const Codigo;
            export declare const Descripcion;
            export declare const Comentarios;
            export declare const KeyEntidad;
            export declare const CodigoPadre;
            export declare const KeyEntidadDescripcion;
            export declare const KeyEntidadKeyGrupoEntidad;
            export declare const KeyEntidadComentarios;
            export declare const CodigoPadreCodigo;
            export declare const CodigoPadreDescripcion;
            export declare const CodigoPadreComentarios;
            export declare const CodigoPadreKeyEntidad;
            export declare const CodigoPadre1;
        }

        [
            'KeyElemento',
            'Codigo',
            'Descripcion',
            'Comentarios',
            'KeyEntidad',
            'CodigoPadre',
            'KeyEntidadDescripcion',
            'KeyEntidadKeyGrupoEntidad',
            'KeyEntidadComentarios',
            'CodigoPadreCodigo',
            'CodigoPadreDescripcion',
            'CodigoPadreComentarios',
            'CodigoPadreKeyEntidad',
            'CodigoPadre1'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}