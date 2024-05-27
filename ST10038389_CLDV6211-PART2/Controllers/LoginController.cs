using Microsoft.AspNetCore.Mvc;
using ST10038389_CLDV6211_PART2.Models;
using System;

namespace ST10038389_CLDV6211_PART2.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel _loginModel;

        // Constructor injection for dependency injection
        public LoginController(LoginModel loginModel)
        {
            _loginModel = loginModel;
        }

        // Renaming method to Login to match its purpose
        [HttpPost]
        public ActionResult Login(string email, string name)
        {
            try
            {
                int userID = _loginModel.SelectUser(email, name);

                if (userID != -1)
                {
                    return RedirectToAction("Index", "Home", new { userID = userID });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login failed. Invalid email or name.");
                    return View("LoginFailed");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request: {ex.Message}");
                return View("LoginFailed");
            }
        }
    }
}
