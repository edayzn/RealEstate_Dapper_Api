using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Models.ViewComponents.HomePage
{
    public class _DefaultHomePageRroductList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageRroductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //n istemci örneği
            var client=_httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:44305/api/Products/ProductListWithCategory");
  

            if(responseMassage.IsSuccessStatusCode)
            {
                var jsonData= await responseMassage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
