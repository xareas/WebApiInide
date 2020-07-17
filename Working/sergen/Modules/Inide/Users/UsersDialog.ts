
namespace Inide.Inide {

    @Serenity.Decorators.registerClass()
    export class UsersDialog extends Serenity.EntityDialog<UsersRow, any> {
        protected getFormKey() { return UsersForm.formKey; }
        protected getIdProperty() { return UsersRow.idProperty; }
        protected getLocalTextPrefix() { return UsersRow.localTextPrefix; }
        protected getNameProperty() { return UsersRow.nameProperty; }
        protected getService() { return UsersService.baseUrl; }
        protected getDeletePermission() { return UsersRow.deletePermission; }
        protected getInsertPermission() { return UsersRow.insertPermission; }
        protected getUpdatePermission() { return UsersRow.updatePermission; }

        protected form = new UsersForm(this.idPrefix);

    }
}