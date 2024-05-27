using Microsoft.AspNetCore.Mvc;
using ST10038389_CLDV6211_PART2.Models;
using System;
using System.Collections.Generic;

namespace ST10038389_CLDV6211_PART2.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductTable> products;

            try
            {
                products = ProductTable.GetAllProducts(); // Fetch all products from the database
            }
            catch (Exception ex)
            {
                // Handle the error appropriately (e.g., log it, show a user-friendly message)
                var errorModel = new ErrorViewModel
                {
                    Message = ex.Message
                };
                return View("Error", errorModel);
            }

            return View(products); // Pass the list of products to the view
        }
    }
}
