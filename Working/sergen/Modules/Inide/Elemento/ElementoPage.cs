
namespace Inide.Inide.Pages
{
    using Serenity;
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.ElementoRow))]
    public class ElementoController : Controller
    {
        [Route("Inide/Elemento")]
        public ActionResult Index()
        {
            return View("~/Modules/Inide/Elemento/ElementoIndex.cshtml");
        }
    }
}