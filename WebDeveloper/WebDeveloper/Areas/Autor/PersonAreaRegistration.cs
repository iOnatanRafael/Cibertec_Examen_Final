using System.Web.Mvc;

namespace WebDeveloper.Areas.Autor
{
    public class AutorAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Autor";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Autor_default",
                "Autor/{action}/{id}",
                new { controller="Autor", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Address_default",
                "Address/{action}/{id}",
                new { controller = "Address", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}