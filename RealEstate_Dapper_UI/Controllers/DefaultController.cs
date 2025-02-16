using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {   
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMassage = await client.GetAsync("https://localhost:44305/api/Categories");


			if (responseMassage.IsSuccessStatusCode)
			{
				var jsonData = await responseMassage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			
			return View();
        }
        [HttpGet]
        public async Task< PartialViewResult >PartialSearch()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:44305/api/Categories");


            if (responseMassage.IsSuccessStatusCode)
            {
                var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return PartialView(values);
            }
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            TempData["searchKeyValue"] = searchKeyValue;
            TempData["propertyCategoryId"] = propertyCategoryId;
            TempData["city"] = city;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}
