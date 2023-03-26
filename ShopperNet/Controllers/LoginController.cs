using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using ShopperNet.DataConnectivity;
using ShopperNet.Models;

namespace ShopperNet.Controllers
{
    public class LoginController : Controller
    {
        private readonly OnlineShopDbContext _context;
        public LoginController(OnlineShopDbContext _context)
        {
            this._context = _context;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ShopLogin shopLogin)
        {
            //var admin = _context.Admin.Any(a => a.AdminEmail == "Admin1706@gmail.com" && a.Password == "Admin");
            //if (admin)
            //{
            //    return RedirectToAction("ItemList", "Admin");
            //}
            var admin = _context.Admin.Any(a => a.AdminEmail == shopLogin.Email && a.Password == shopLogin.Password);
            if (admin)
            {
                TempData["Alert1"] = "Admin login successfully";
                string AdminEmail = "" + shopLogin.Email;
                TempData["User"] = AdminEmail;
                return RedirectToAction("DashBoard", "Admin");
            }

            var check = _context.Users.Where(a => a.Email.Equals(shopLogin.Email) && a.Password.Equals(shopLogin.Password)).FirstOrDefault();
           

            if (check != null)
            {

               
                TempData["Alert2"] = "Login successfully";
                string Email = ""+shopLogin.Email;
                TempData["User"] = Email;
                return RedirectToAction("Index", "Home");//this was blocked and then was not redirecting
            }
            TempData["Alert3"] = "User Not Found";
            //return RedirectToAction("Create", "Registration");

            return View();

           
        }

        public ActionResult Logout()
        {
            //HttpContext.Session.Clear();
            //HttpContext.Session.Remove("userName");
            return RedirectToAction("login", "Login");
        }

        

}
}