using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_UI.Models.ViewComponents.HomePage
{
    public class _DefaultSubFeatureComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSubFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:44305/api/SubFeatures");


            if (responseMassage.IsSuccessStatusCode)
            {
                var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
