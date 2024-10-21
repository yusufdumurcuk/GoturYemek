using GoturYemek.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization; // Yetkilendirme için gerekli
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    YemekSiparisDbContext _dbContext;

    public AccountController(YemekSiparisDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        var passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, user.Password);
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user != null)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Kullanıcı giriş yapıyor
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("AnaSayfa");
            }
        }

        ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
        return View();
    }

    // Profil sayfası
    [Authorize]
    public IActionResult Profil()
    {
        return View();
    }

    // Sepet sayfası
    [Authorize]
    public IActionResult Sepet()
    {
        return View();
    }

    // Katagoriler sayfası
    [Authorize]
    public IActionResult Katagoriler()
    {
        return View();
    }

    public IActionResult AnaSayfa()
    {
        return View();
    }

    // Kullanıcının çıkış yapması
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }

}
