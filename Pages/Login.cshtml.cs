using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MyStore.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext dBContext;
        [BindProperty]
        public LoginVM Login { get; set; }
        public string Message { get; set; }
        public LoginModel(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            var user = await dBContext.AppUsers.AsNoTracking().FirstOrDefaultAsync(u => u.Email == Login.Email && u.PasswordHash == Login.Password);
            if (user is null) { Message = "Wrong UserName Or Password"; return Page(); }
            var claims = new List<Claim>()
            {
                new Claim (ClaimTypes.Name , user.UserName),
                new Claim (ClaimTypes.Email, user.Email),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(claimsPrincipal);

            return RedirectToPage("index");
        }

    }

    public class LoginVM
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
