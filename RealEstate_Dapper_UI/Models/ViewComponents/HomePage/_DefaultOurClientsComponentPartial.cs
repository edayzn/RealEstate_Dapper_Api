using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Models.ViewComponents.HomePage
{
    public class _DefaultOurClientsComponentPartial:ViewComponent  
    {
        public IViewComponentResult Invoke()
        { 
            return View(); 
        }
    }
}
