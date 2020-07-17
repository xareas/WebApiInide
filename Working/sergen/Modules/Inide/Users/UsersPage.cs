
namespace Inide.Inide.Pages
{
    using Serenity;
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.UsersRow))]
    public class UsersController : Controller
    {
        [Route("Inide/Users")]
        public ActionResult Index()
        {
            return View("~/Modules/Inide/Users/UsersIndex.cshtml");
        }
    }
}