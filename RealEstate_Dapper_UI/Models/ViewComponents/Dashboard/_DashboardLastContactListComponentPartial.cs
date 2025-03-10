﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ContactDtos;

namespace RealEstate_Dapper_UI.Models.ViewComponents.Dashboard
{
    public class _DashboardLastContactListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _DashboardLastContactListComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Contacts/GetLastFourContact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<LastFourContactResultDto>>(jsonData);
                return View(values);
            }
            return View(); ;
        }
    }
}
