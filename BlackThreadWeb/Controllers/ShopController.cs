using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using BlackThreadWeb.Data;
using BlackThreadWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlackThreadWeb.Controllers
{
    public class ShopController : Controller
    {
        // db connection
        private readonly ApplicationDbContext _context;

        //constructor that accepts a db context object
        public ShopController(ApplicationDbContext context)
        {
            // instantiate an instance of the db context
            _context = context;
        }

        public IActionResult Index()
        {
            // use the db context and Categories DbSet
            // to fetch a list from the db
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();

            return View(categories);
        }

        // GET: /Shop/Browse/3
        public IActionResult Browse(int id)
        {
            // query the db for the products in the selected category
            var products = _context.Products.Include(p => p.Category).Where(p => p.CategoryId == id).OrderBy(p => p.Name).ToList();

            // get the Category name for display in the page heading
            ViewBag.Category = products[0].Category.Name;
            //ViewBag.Category = _context.Categories.Find(id).Name.ToString();

            // load the Browse view & pass the list of products for display
            return View(products);
        }

        // POST: /Shop/AddToCart
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddToCart(int ProductId, int Quantity)
        {
            // look up the current product price
            var price = _context.Products.Find(ProductId).Price;
            
            // set the customer
            var customerId = GetCustomerId();

            // create/populate a new cart object
            var cart = new Cart
            {
                ProductId = ProductId,
                Quantity = Quantity,
                Price = price,
                CustomerId = customerId,
                DateCreated = DateTime.Now
            };

            // save to Cart table in db
            _context.Carts.Add(cart);
            _context.SaveChanges();

            // redirect to cart page
            return RedirectToAction("Cart");
        }

        // Check session for existing Session ID. If none exists, first create it then return it
        private string GetCustomerId()
        {
            // check if there is already a customerId session vairable
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                // this is the first item in this user's cart: generate Guid and store in session variable
                HttpContext.Session.SetString("CustomerId", Guid.NewGuid().ToString());
            }

            return HttpContext.Session.GetString("CustomerId");
        }

        // GET: /Shop/Cart
        public IActionResult Cart()
        {
            // get items in current user's cart
            //var cartItems = _context.Carts.Where(c => c.CustomerId == HttpContext.Session.GetString("CustomerId")).ToList();
            var cartItems = _context.Carts.Include(c => c.Product).Where(c => c.CustomerId == HttpContext.Session.GetString("CustomerId")).ToList();
            // display a view and pass the items for display
            return View(cartItems);
        }
    }
}
