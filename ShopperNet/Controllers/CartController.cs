using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using ShopperNet.DataConnectivity;
using ShopperNet.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShopperNet.Controllers
{
    public class CartController : Controller
    {
        //List<Cart> cart = new List<Cart>();
        private readonly OnlineShopDbContext _context;
        public CartController(OnlineShopDbContext _context) 
        { 
                this._context = _context;
        }

        public IActionResult shoppercart()//shopping cart where the product after add to cart is shown
        {
            string userEmail= (string)TempData["User"];

            var itemdetails = _context.ShopperCart.Where(s=>s.Email==userEmail).ToList();
            return View(itemdetails);
            
       }

        [HttpGet]
        
        public ActionResult Edit(int Id)//orders page
        {

            var item = _context.ShopperCart.Find(Id);

            

            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Cart update)//orders page
        {
            string userEmail = (string)TempData["User"];
            var useraddress = _context.profile.Where(s => s.Email == userEmail).First();
            int TotalPrice = update.ItemPrice * update.Quantity;
            _context.Database.ExecuteSql($"insertorder @ItemId = {update.ItemId},@Quantity = {update.Quantity}, @Email ={userEmail},@Address = {useraddress.Address}, @TotalPrice ={TotalPrice}");

            return  RedirectToAction("shipping");

        }

        [HttpGet]

        public IActionResult shipping()//this page is the page where we go after we confirm the order 
        {
            string userEmail = (string)TempData["User"];
            var address = _context.shippingadd.Where(s => s.Email == userEmail);
            return View(address);
        }

        [HttpGet]
        public IActionResult shippingaddressedit(int shipaddid)//this is used to the edit the shipping address
        {

            var usershipaddd = _context.shippingadd.Find(shipaddid);
            return View(usershipaddd);
        }

        [HttpPost]
        public IActionResult shippingaddressedit(shippingadd shippingadd)
        {
            string userEmail = (string)TempData["User"];
            _context.Database.ExecuteSql($"updateadd  @Email={shippingadd.Email}, @Address={shippingadd.Address}");
            return RedirectToAction("shipping");
        }

        public IActionResult Continue(int shipaddid)//by clicking on this user will continue with same address without editing
        {
            string userEmail = (string)TempData["User"];
            var add = _context.shippingadd.Find(shipaddid).Address;
            _context.Database.ExecuteSql($"updateadd  @Email={userEmail}, @Address={add}");

            return RedirectToAction("Exitpage");
        }

        public IActionResult CreateAdd()//this is the page to add the new address to shipping address(max 3)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAdd(shippingadd shippingadd)
        {
            string userEmail = (string)TempData["User"];
            int addcount = _context.shippingadd.Where(s=>s.Email==userEmail).Count();
            if(addcount <=2)
            {
                _context.Database.ExecuteSql($"addaddress  @Email={shippingadd.Email}, @Address={shippingadd.Address}");
                return RedirectToAction("shipping");
            }
            TempData["AddAlert"] = "You cannot Add more than 3 addressess";
            return View();
        }



        public IActionResult Exitpage()
        {
            return View();
        }

        public IActionResult Decrease(int ItemId)
        {
            string userEmail = (string)TempData["User"];
            _context.Database.ExecuteSql($"decreasequantity @ItemId={ItemId}, @Email = {userEmail}");
            return RedirectToAction("shoppercart");
        }

        public IActionResult Increase(int ItemId)
        {
            string userEmail = (string)TempData["User"];
            _context.Database.ExecuteSql($"increasequantity @ItemId={ItemId}, @Email = {userEmail}");
            return RedirectToAction("shoppercart");
        }

        [HttpGet]
        public IActionResult Deleteproductfromcart(int ItemId)
        {
            string userEmail = (string)TempData["User"];
            _context.Database.ExecuteSql($"removecartproduct @ItemId={ItemId}");
            return RedirectToAction("shoppercart");
        }

    }
}

