
namespace Inide.Inide {

    @Serenity.Decorators.registerClass()
    export class ElementoGrid extends Serenity.EntityGrid<ElementoRow, any> {
        protected getColumnsKey() { return 'Inide.Elemento'; }
        protected getDialogType() { return ElementoDialog; }
        protected getIdProperty() { return ElementoRow.idProperty; }
        protected getInsertPermission() { return ElementoRow.insertPermission; }
        protected getLocalTextPrefix() { return ElementoRow.localTextPrefix; }
        protected getService() { return ElementoService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}