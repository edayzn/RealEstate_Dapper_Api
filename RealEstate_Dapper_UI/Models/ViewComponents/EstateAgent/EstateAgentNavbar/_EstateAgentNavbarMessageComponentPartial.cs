using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Models.ViewComponents.EstateAgent.EstateAgentNavbar
{
    public class _EstateAgentNavbarMessageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
             return View();
        }
    }
}
