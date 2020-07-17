
namespace Inide.Inide {
    export class ElementoForm extends Serenity.PrefixedContext {
        static formKey = 'Inide.Elemento';
    }

    export interface ElementoForm {
        Codigo: Serenity.StringEditor;
        Descripcion: Serenity.StringEditor;
        Comentarios: Serenity.StringEditor;
        KeyEntidad: Serenity.IntegerEditor;
        CodigoPadre: Serenity.StringEditor;
    }

    [,
        ['Codigo', () => Serenity.StringEditor],
        ['Descripcion', () => Serenity.StringEditor],
        ['Comentarios', () => Serenity.StringEditor],
        ['KeyEntidad', () => Serenity.IntegerEditor],
        ['CodigoPadre', () => Serenity.StringEditor]
    ].forEach(x => Object.defineProperty(ElementoForm.prototype, <string>x[0], {
        get: function () {
            return this.w(x[0], (x[1] as any)());
        },
        enumerable: true,
        configurable: true
    }));
}