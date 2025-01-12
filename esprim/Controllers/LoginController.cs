using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using mini.project.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class LoginController : Controller
{
    private readonly MyDbContext _context;

    public LoginController(MyDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            TempData["ErrorMessage"] = "Username and Password are required.";
            return View();
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role) // Assuming 'Role' is a property of User
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true // Persistent across sessions
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            TempData["SuccessMessage"] = "Login successful!";
            return RedirectToAction("Index", "Dashboard");
        }
        else
        {
            TempData["ErrorMessage"] = "Invalid username or password.";
            return View();
        }
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Login");
    }
}
