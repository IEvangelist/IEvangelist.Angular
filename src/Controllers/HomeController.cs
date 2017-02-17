using Microsoft.AspNetCore.Mvc;

namespace IEvangelist.Angular.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View();
    }
}