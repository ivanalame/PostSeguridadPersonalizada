using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace PostSeguridadPersonalizada.Controllers
{
    public class ManagedController : Controller
    {

        public async Task< IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(string username, string password)
        {
            if(username.ToLower()=="admin" && password.ToLower()=="admin")
            {
                //DEBEMO CREAR UNA IDENTIDAD PARA EL USUARIO E INDICAR QUE NUESTRO USER TENDRA NAME Y ROLE
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name, ClaimTypes.Role);

                //ESTOS CLAIMS INDICAN CARACTERISTICAS DEL USUARIO
                Claim claimUserName = new Claim(ClaimTypes.Name, username);

                Claim claimRole = new Claim(ClaimTypes.Role, "USUARIO");

                identity.AddClaim(claimUserName);

                identity.AddClaim(claimRole);
                
                //CREAMOS EL USER PRINCIPAL QUE SERA EL QUE ESTARA DENTRO DE NUESTRA APP (SESSION)
                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                //VALIDAMOS AL USUARIO EN EL SISTEMA
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                //LLEVAMOS AL USUARIO A SU PERFIL
                return RedirectToAction("Perfil", "DEPORTES");
            }
            else
            {
                ViewData["MENSAJE"] = "Credenciales incorrectas";
                return View();
            }

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Deportes", "Deportes");
        }
    }
}
