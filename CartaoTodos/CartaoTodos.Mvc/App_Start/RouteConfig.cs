using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CartaoTodos.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "RemoverPerfil",
                url: "Usuarios/RemoverPerfil/{usuarioId}/{perfilId}",
                defaults: new { controller = "Usuarios", action = "RemoverPerfil" }
            );

            routes.MapRoute(
                name: "AdicionarPerfil",
                url: "Usuarios/AdicionarPerfil/{usuarioId}/{perfilId}",
                defaults: new { controller = "Usuarios", action = "AdicionarPerfil" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
