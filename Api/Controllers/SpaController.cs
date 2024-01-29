using System.Web.Mvc;

namespace Api.Controllers
{
  public class SpaController : Controller
  {
    public ActionResult Index()
    {
      return File("~/wwwroot/index.html", "text/html");
    }
  }
}
