using System;
using System.Collections.Generic; // Ensure this is included for List<T>
using Microsoft.AspNetCore.Mvc;
using ST10038389_CLDV6211_PART2.Models;

namespace ST10038389_CLDV6211_PART2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public IActionResult Index()
        {
            try
            {
                // Retrieve all products from the ProductTable
                var products = ProductTable.GetAllProducts();
                // Pass the retrieved products to the view
                return View(products);
            }
            catch (Exception ex)
            {
                // Handle exceptions and possibly log them
                ViewBag.ErrorMessage = "Error retrieving products: " + ex.Message;
                return View("Error");
            }
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            // Return the create view
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductTable product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert the new product into the database
                    var result = product.InsertProduct();
                    if (result > 0)
                    {
                        // If insertion is successful, redirect to the index page
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error inserting product.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions and possibly log them
                    ModelState.AddModelError("", "Error inserting product: " + ex.Message);
                }
            }
            // If the model state is invalid or insertion failed, return the same view with the model state
            return View(product);
        }
    }
}
