using Serenity.Navigation;
using MyPages = Inide.Inide.Pages;

[assembly: NavigationLink(int.MaxValue, "Inide/Users", typeof(MyPages.UsersController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Inide/Elemento", typeof(MyPages.ElementoController), icon: null)]