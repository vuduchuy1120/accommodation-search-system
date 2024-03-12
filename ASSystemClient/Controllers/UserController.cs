using Microsoft.AspNetCore.Mvc;

namespace ASSystemClient.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
