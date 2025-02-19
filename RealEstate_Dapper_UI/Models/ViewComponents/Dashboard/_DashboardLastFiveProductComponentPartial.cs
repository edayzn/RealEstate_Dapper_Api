using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Models.ViewComponents.Dashboard
{
    public class _DashboardLastFiveProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSetting;
        public _DashboardLastFiveProductComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSetting)
        {
            _httpClientFactory = httpClientFactory;
            _apiSetting = apiSetting.Value;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSetting.BaseUrl);
            var responseMessage = await client.GetAsync("Products/LastProductFiveList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLastFiveProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View(); ;
        }
    }
}
