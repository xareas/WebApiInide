
namespace Inide.Inide {

    @Serenity.Decorators.registerClass()
    export class ElementoDialog extends Serenity.EntityDialog<ElementoRow, any> {
        protected getFormKey() { return ElementoForm.formKey; }
        protected getIdProperty() { return ElementoRow.idProperty; }
        protected getLocalTextPrefix() { return ElementoRow.localTextPrefix; }
        protected getNameProperty() { return ElementoRow.nameProperty; }
        protected getService() { return ElementoService.baseUrl; }
        protected getDeletePermission() { return ElementoRow.deletePermission; }
        protected getInsertPermission() { return ElementoRow.insertPermission; }
        protected getUpdatePermission() { return ElementoRow.updatePermission; }

        protected form = new ElementoForm(this.idPrefix);

    }
}