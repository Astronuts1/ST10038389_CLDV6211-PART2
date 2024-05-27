using Microsoft.AspNetCore.Mvc;
using ST10038389_CLDV6211_PART2.Models;
using System;

namespace ST10038389_CLDV6211_PART2.Controllers
{
    public class UserController : Controller
    {
        private readonly UserTable _usrtbl; // Declare _usrtbl variable with IUserTable interface type.

        public UserController(UserTable userTable) // Inject IUserTable dependency.
        {
            _usrtbl = userTable ?? throw new ArgumentNullException(nameof(userTable)); // Assign injected IUserTable instance to _usrtbl variable.
        }

        [HttpPost] // Handles the POST request to input a user in.
        public IActionResult About(UserTable user) // Change parameter type to User instead of UserTable.
        {
            if (user == null)
            {
                return BadRequest("User data cannot be null");
            }

            try
            {
                _usrtbl.InsertUser(user); // Inserts a user into the database.
                return RedirectToAction("Privacy", "Home"); // Sends the Privacy action back to HomeController.
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed.
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet] // Handles the GET request to display user information.
        public IActionResult About()
        {
            try
            {
                var users = _usrtbl.GetAllUsers(); // Get all users from the database.
                return View(users); // Sends user information to the View.
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed.
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
