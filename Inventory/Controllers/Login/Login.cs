using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Controllers.Login
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthenticateLogin(Models.Login.Login login)
        {

            return RedirectToAction();

        }

        public IActionResult Register(Models.Login.Login register)
        {

            return RedirectToAction();

        }
    }
}
