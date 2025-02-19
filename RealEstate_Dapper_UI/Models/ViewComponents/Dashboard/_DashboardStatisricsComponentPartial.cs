using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace RealEstate_Dapper_UI.Models.ViewComponents.Dashboard
{
    public class _DashboardStatisricsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DashboardStatisricsComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
            #region Statistics1 -ToplaamİlanSayısı
            
            var responseMessage1 = await client.GetAsync("Statistics/ProductCount");
            var jsonData1= await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion

            #region Statistics2 - En BaşarılıPersonel
           
            var responseMessage2 = await client.GetAsync("Statistics/EmployeeNameByMaxProductCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData2;
            #endregion

            #region Statistics3- İlandakiŞehirSayısı
            
            var responseMessage3 = await client.GetAsync("Statistics/DifferentCityCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData3;
            #endregion

            #region Statistics4 -OrtalamaKiraFiyatı
           
            var responseMessage4 = await client.GetAsync("Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion
            return View();
        }
    }
}
