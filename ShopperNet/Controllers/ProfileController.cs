using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopperNet.DataConnectivity;
using ShopperNet.Models;

namespace ShopperNet.Controllers
{
    public class ProfileController : Controller
    {
        private readonly OnlineShopDbContext _context;
        public ProfileController(OnlineShopDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Profile()
        {
            string Email = (string)TempData["User"];
            var pro = _context.profile.Where(s => s.Email == Email).ToList();
            return View(pro);
        }
        [HttpGet]
        public IActionResult Editprofile(int id)
        {
            var edit = _context.profile.Find(id);
            return View(edit);
        }

        [HttpPost]
        public IActionResult Editprofile(Profile profile)
        {
            _context.Database.ExecuteSql($"editprofile @Name={profile.Name}, @Email={profile.Email}, @phone={profile.phone},@DateofBirth={profile.DateofBirth}, @Address={profile.Address}");
            _context.Database.ExecuteSql($"addaddress  @Email={profile.Email}, @Address={profile.Address}");
            return RedirectToAction("Profile");

        }

    }
}
