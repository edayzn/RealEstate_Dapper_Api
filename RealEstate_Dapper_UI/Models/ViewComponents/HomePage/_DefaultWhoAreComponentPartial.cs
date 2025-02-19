using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using ResultServiceDto = RealEstate_Dapper_UI.Dtos.ServiceDtos.ResultServiceDto;

namespace RealEstate_Dapper_UI.Models.ViewComponents.HomePage
{
    public class _DefaultWhoAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DefaultWhoAreComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        { 
            var client=_httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
            //var client2=_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("WhoWeAreDetail");
            var responseMessage2 = await client.GetAsync("Services");

            if(responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
            
                 var jsonData=await responseMessage.Content.ReadAsStringAsync();
                 var jsonData2=await responseMessage2.Content.ReadAsStringAsync();


                var value=JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2=JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);
                ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.subTitle = value.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);
            }
            return View();

        }
    }
}
