﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Models.ViewComponents.HomePage
{
    public class _DefaultScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
