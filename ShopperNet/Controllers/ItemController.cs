using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopperNet.DataConnectivity;
using ShopperNet.Models;

namespace ShopperNet.Controllers
{
    public class ItemController : Controller
    {
        private readonly OnlineShopDbContext _context;
        public ItemController(OnlineShopDbContext _context)
        {
            this._context = _context;
        }
        // GET: ItemController
        public ActionResult Index()//list view
        {
            var item = _context.Items.ToList();
            return View(item);
        }

        [HttpGet]
        public IActionResult Details(int ItemId)//details view
        {
            var item = _context.Items.Find(ItemId);
            
            return View(item);
        }

        public IActionResult addtocart(int ItemId)//edit view
        {
            var item = _context.Items.Find(ItemId);
            return View(item);
        }

        [HttpPost]
        public IActionResult addtocart(Items items)//edit view
        {
            string Email = (string)TempData["User"];
            _context.Database.ExecuteSql($"getcartdetails @ItemId = {items.ItemId},@ItemName = {items.Name},@ItemPrice = {items.ItemPrice},@Quantity = {1},@Email = {Email}");
            return View();
        }

    }
}
