using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using ResultServiceDto = RealEstate_Dapper_UI.Dtos.ServiceDtos.ResultServiceDto;

namespace RealEstate_Dapper_UI.Models.ViewComponents.HomePage
{
    public class _DefaultWhoAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        { 
            var client=_httpClientFactory.CreateClient();
            var client2=_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44305/api/WhoWeAreDetail");
            var responseMessage2 = await client2.GetAsync("https://localhost:44305/api/Services");

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
