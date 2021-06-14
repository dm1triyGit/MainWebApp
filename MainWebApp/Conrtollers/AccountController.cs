using AutoMapper;
using BLL.Constants;
using BLL.DTO;
using BLL.Interfaces;
using WebUI.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace WebUI.Conrtollers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {                                
            var user = _userService
                .Find(x => x.Login == model.Login
                    && x.Password == model.Password)
                .FirstOrDefault();

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, AccountConstants.NotCorrectLoginAndPass);
                return View("Login");
            }

            await Authenticate(user); 

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            bool result = false;
            var newUser = new UserDTO();

            var user = _userService
               .Find(x => x.Login == model.Login
                   || x.Password == model.Password)
               .FirstOrDefault();

            if (user == null && ModelState.IsValid)
            {
                newUser = BuildUser(model);
                result = _userService.Create(newUser);
            }

            if (!result)
            {
                ModelState.AddModelError(string.Empty, AccountConstants.ErrorCreateUser);
                return View("Register");
            }

            await Authenticate(newUser);

            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleName)
            };

            ClaimsIdentity id = new ClaimsIdentity(
                claims,
                AccountConstants.AuthenticatedType,
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
                );

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private UserDTO BuildUser(RegisterViewModel model)
        {
            var role = _userService.GetRoleByName(AccountConstants.UserRoleName);

            var user = _mapper.Map<RegisterViewModel, UserDTO>(model);

            user.RoleId = role.Id;
            user.RoleName = role.Name;

            return user;
        }

    }
}
