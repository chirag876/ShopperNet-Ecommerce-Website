using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopperNet.DataConnectivity;
using ShopperNet.Models;

namespace ShopperNet.Controllers
{
    public class ShopRegistrationController : Controller
    {
       private readonly OnlineShopDbContext _context;

        public ShopRegistrationController(OnlineShopDbContext _context)
        {
            this._context = _context;
        }
        //[HttpGet]
  
        //public ActionResult Index()
        //{
        //    return View(_context.Users.ToList());
        //}

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddUser adduser)
        {

            if (ModelState.IsValid)
            {

                //check whether name is already exists in the database or not
                bool nameAlreadyExists = _context.Users.Any(s => s.Email == adduser.Email);


                if (nameAlreadyExists)
                {
                    ModelState.AddModelError(string.Empty, "user already exists.");
                    TempData["Alert4"] = "user already exists";
                    return View(adduser);
                }
            }
            _context.Database.ExecuteSql($"AddUser @Name = {adduser.Name},@Email = {adduser.Email},@Password = {adduser.Password},@Phone = {adduser.Phone},@Country = {adduser.Country}");
            return RedirectToAction("Login", "Login");
        }



        //[HttpPost]
        //public async Task<IActionResult> Create(AddUser adduser)
        //{
        //    var shop = new ShopRegistration()
        //    {
        //        Id = adduser.Id,
        //        Name = adduser.Name,
        //        Email = adduser.Email,
        //        Password= adduser.Password,
        //        Phone= adduser.Phone,
        //        Country= adduser.Country
        //    };
        //    await _context.Users.AddAsync(shop);
        //    await _context.SaveChangesAsync();
        //    //studentList.Add(student);
        //    return RedirectToAction("Index");
        //}

    }
}
