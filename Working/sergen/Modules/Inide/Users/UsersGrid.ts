
namespace Inide.Inide {

    @Serenity.Decorators.registerClass()
    export class UsersGrid extends Serenity.EntityGrid<UsersRow, any> {
        protected getColumnsKey() { return 'Inide.Users'; }
        protected getDialogType() { return UsersDialog; }
        protected getIdProperty() { return UsersRow.idProperty; }
        protected getInsertPermission() { return UsersRow.insertPermission; }
        protected getLocalTextPrefix() { return UsersRow.localTextPrefix; }
        protected getService() { return UsersService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}