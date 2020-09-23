using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JamiiWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace JamiiWeb.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            // crate some dummy data
            var categories = new List<Category>();
            // make 10 fake objects
            for (int i = 1; i < 11; i++)
            {
                categories.Add(new Category() { Id = i, Name = "Category " + i.ToString() });
            }

            // pass the populated list to the view to display
            return View(categories);
        }

        public IActionResult Browse(string category)
        {
            // pass incoming category to the Browse view using the ViewBag object
            ViewBag.category = category;
            return View();
        }
    }
}
