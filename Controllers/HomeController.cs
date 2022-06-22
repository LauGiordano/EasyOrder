using EasyOrder.Datos;
using EasyOrder.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EasyOrder.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseDeDatos _context;

        public HomeController(BaseDeDatos context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            var usuario = _context
                    .Users
                    .Where(o => o.Email.ToUpper().Equals(email.ToUpper()))
                    .FirstOrDefault();

            if (usuario == null)
            {
                //Quiero buscar en la base si existe. Si no existe, tengo que crearlo!
                return RedirectToAction("Create", "Users");
            }
            else if (password == usuario.Password)
            {
                if (email == "ml.giordano@hotmail.com") //Quiero que sea administrado!
                {

                    ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                    // El lo que luego obtendré al acceder a User.Identity.Name
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Name));

                    // Se utilizará para la autorización por roles
                    identity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));

                    // Lo utilizaremos para acceder al Id del usuario que se encuentra en el sistema.
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));

                    // Lo utilizaremos cuando querramos mostrar el nombre del usuario logueado en el sistema.
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, usuario.Name));

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    // En este paso se hace el login del usuario al sistema
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal).Wait();


                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    // El lo que luego obtendré al acceder a User.Identity.Name
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Name));
                    // Se utilizará para la autorización por roles
                    identity.AddClaim(new Claim(ClaimTypes.Role, "USUARIO"));
                    // Lo utilizaremos para acceder al Id del usuario que se encuentra en el sistema.
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));
                    // Lo utilizaremos cuando querramos mostrar el nombre del usuario logueado en el sistema.
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, usuario.Name));
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    // En este paso se hace el login del usuario al sistema
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                    return RedirectToAction("Index", "Orders");
                    
                }
            }
            else
            {
                TempData["Message"] = "La contraseña es incorrecta";
                return View();
            }


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}