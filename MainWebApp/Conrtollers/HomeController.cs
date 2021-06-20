using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Conrtollers
{
    [Authorize]
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }     
    }
}
