using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientExample.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> GizliSayfaAsync()
        {
            var a = User.Claims;
            var prop = (await HttpContext.AuthenticateAsync()).Properties.Items;
            return View();
        }
    }
}
