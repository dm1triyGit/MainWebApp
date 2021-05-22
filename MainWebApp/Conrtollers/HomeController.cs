using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainWebApp.Conrtollers
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="user, admin")]
        public IActionResult Index()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"ваша роль: {role}");
        }     
    }
}
