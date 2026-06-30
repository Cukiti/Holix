using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Holix.Controllers
{
    public class TokenRequest
    {
        public string? IdToken { get; set; }
    }

    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyToken([FromBody] TokenRequest request)
        {
            if (string.IsNullOrEmpty(request?.IdToken))
            {
                return BadRequest(new { error = "Token is missing" });
            }

            try
            {
                // Verify the ID Token from the client
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.IdToken);
                var uid = decodedToken.Uid;
                
                var email = decodedToken.Claims.ContainsKey("email") ? decodedToken.Claims["email"]?.ToString() ?? "" : "";
                var name = decodedToken.Claims.ContainsKey("name") ? decodedToken.Claims["name"]?.ToString() ?? email : email;

                // Create ASP.NET Core Claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, uid),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, name)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(14)
                };

                // Sign in using standard Cookie Authentication
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Ok(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
