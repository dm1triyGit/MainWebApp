using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Constants;
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
