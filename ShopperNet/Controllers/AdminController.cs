using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopperNet.DataConnectivity;
using ShopperNet.Models;

namespace ShopperNet.Controllers
{
    public class AdminController : Controller
    {
        private readonly OnlineShopDbContext _context;
        public AdminController(OnlineShopDbContext _context)
        {
            this._context = _context;
        }
    
        public IActionResult DashBoard()
        {
            return View();
        }
        public IActionResult UserList()
        {
            var userList = _context.Users.ToList();
            return View(userList);
        }

        public IActionResult ItemList()
        {
            var ItemList = _context.Items.ToList();
            return View(ItemList);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Items item)
        {
            var items = new Items()
            {
                ItemId = item.ItemId,
                Name = item.Name,
                Description = item.Description,

                ItemImage = item.ItemImage,

                ItemPrice = item.ItemPrice
            };
            await _context.Items.AddAsync(items);
            await _context.SaveChangesAsync();
            //studentList.Add(student);
            return RedirectToAction("Index" ,"Item");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int ItemId)
        {
            var item = _context.Items.Find(ItemId);
            _context.Items.Remove(item);
            return RedirectToAction("ItemList");
        }

        public IActionResult orderlist()
        {
            var orderlist = _context.orders.ToList();
            return View(orderlist);
        }


       
    }
}
