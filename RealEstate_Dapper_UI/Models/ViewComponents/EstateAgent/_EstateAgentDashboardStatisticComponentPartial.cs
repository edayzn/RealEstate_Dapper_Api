using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Models.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService = null)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();

            #region Statistics1 -ToplaamİlanSayısı

            var responseMessage1 = await client.GetAsync("https://localhost:44305/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion

            #region Statistics2 - EmlakçınınToplamİlanSayısı

            var responseMessage2 = await client.GetAsync("https://localhost:44305/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id="+id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeByProductCount = jsonData2;
            #endregion

            #region Statistics3- AktifİlanSayısı

            var responseMessage3 = await client.GetAsync("https://localhost:44305/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id="+id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusTrue = jsonData3;
            #endregion

            #region Statistics4 -PasifİlanSayısı

            var responseMessage4 = await client.GetAsync("https://localhost:44305/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id="+id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusFalse = jsonData4;
            #endregion
            return View();
        }
    }
}
