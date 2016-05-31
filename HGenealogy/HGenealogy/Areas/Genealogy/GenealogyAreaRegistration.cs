using System.Web.Mvc;

namespace HGenealogy.Areas.Genealogy
{
    public class GenealogyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Genealogy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {         
            context.MapRoute(
                "Genealogy_default",
                "Genealogy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}