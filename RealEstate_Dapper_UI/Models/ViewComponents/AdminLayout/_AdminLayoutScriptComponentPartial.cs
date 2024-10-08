using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Models.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
