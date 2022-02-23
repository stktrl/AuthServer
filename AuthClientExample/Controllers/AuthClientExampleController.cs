using Microsoft.AspNetCore.Mvc;

namespace AuthClientExample.Controllers
{
    public class AuthClientExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
