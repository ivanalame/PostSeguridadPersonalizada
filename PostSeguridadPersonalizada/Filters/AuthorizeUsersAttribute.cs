using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PostSeguridadPersonalizada.Filters
{
    public class AuthorizeUsersAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        //ESTE FILTRO ES EL QUE VALIDARA SI EXISTIMOS EN LA APP O NO
        //SI NO ESTAMOS VALIDADOS EN NUESTRA APP, NOS LLEVARA A LOGIN
        //SI ESTAMOS VALIDADOS, NO HAREMOS NADA
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            //PREGUNTAREMOS SI EL USER YA ESTA  AUTENTIFICADO
            if (user.Identity.IsAuthenticated == false)
            {
                // CREAMOS LA RUTA A NUESTRA DIRECCION

                RouteValueDictionary rutaLogin =new RouteValueDictionary
                    (
                       new { controller = "Managed", action = "Login" }
                    );

                //LLEVAMOS AL USUARIO A Login 
                context.Result =new RedirectToRouteResult(rutaLogin);
            }
           
        }
    }
}
