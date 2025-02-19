using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Models;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ServiceController : Controller
    {
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly ApiSettings _apiSettings;
        public ServiceController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
            {

                var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
                var responseMassage = await client.GetAsync("Services");


                if (responseMassage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMassage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                    return View(values);
                }
                return View();
            }
            [HttpGet]
            public IActionResult CreateService()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
            {
            createServiceDto.ServiceStatus = true;
                var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var jsonData = JsonConvert.SerializeObject(createServiceDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("Services", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            public async Task<IActionResult> DeleteService(int id)
            {
                var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
                var reponseMessage = await client.DeleteAsync($"Services/{id}");
                if (reponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            public async Task<IActionResult> UpdateService(int id)
            {
                var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
                var responseMessage = await client.GetAsync($"Services/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                    return View(values);
                }
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
            {
                var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var jsonData = JsonConvert.SerializeObject(updateServiceDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("Services", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    }

