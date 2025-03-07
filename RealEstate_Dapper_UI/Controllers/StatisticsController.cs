﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public StatisticsController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        
        public async Task<IActionResult> Index()
        {
            #region Statistics1
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);

            var responseMessage1 = await client.GetAsync("Statistics/ActiveCategoryCount");
            var jsonData1= await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData1;
            #endregion
            #region Statistics2
            //var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion
            #region Statistics3
           // var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client.GetAsync("Statistics/ApartmenCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmenCount = jsonData3;
            #endregion
            #region Statistics4
            //var client4 = _httpClientFactory.CreateClient();
            
            var responseMessage4 = await client.GetAsync("Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion
            #region Statistics5
            //var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client.GetAsync("Statistics/AverageProductPriceBySale");
            var jsonData5 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = jsonData5;
            #endregion
            #region Statistics6
            //var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client.GetAsync("Statistics/AverageRoomCount");
            var jsonData6 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.averageRoomCount = jsonData6;
            #endregion
            #region Statistics7
           // var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client.GetAsync("Statistics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData7;
            #endregion
            #region Statistics8
            //var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client.GetAsync("Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData8;
            #endregion
            #region Statistics9
            //var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client.GetAsync("Statistics/CityNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCount = jsonData9;
            #endregion
            #region Statistics10
            //var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client.GetAsync("Statistics/DifferentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData10;
            #endregion
            #region Statistics11
            //var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client.GetAsync("Statistics/EmployeeNameByMaxProductCount");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData11;
            #endregion
            #region Statistics12
            //var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client.GetAsync("Statistics/LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.lastProductPrice = jsonData12;
            #endregion
            #region Statistics13
            //var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client.GetAsync("Statistics/NewestBuildingYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.newestBuildingYear = jsonData13;
            #endregion
            #region Statistics14
            //var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client.GetAsync("Statistics/OldestBuildingYear");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.oldestBuildingYear = jsonData10;
            #endregion
            #region Statistics15
            //var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client.GetAsync("Statistics/PassiveCategoryCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.passiveCategoryCount = jsonData15;
            #endregion
            #region Statistics16
            //var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client.GetAsync("Statistics/ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData16;
            #endregion
            return View();

        }
    }
}
