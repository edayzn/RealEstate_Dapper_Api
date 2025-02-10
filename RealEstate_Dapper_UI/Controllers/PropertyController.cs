using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //n istemci örneği
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:44305/api/Products/ProductListWithCategory");


            if (responseMassage.IsSuccessStatusCode)
            {
                var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 9;
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:44305/api/Products/GetProductByProductId?id="+id);

            var jsonData = await responseMassage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

            var responseMassage2 = await client.GetAsync("https://localhost:44305/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var jsonData2 = await responseMassage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);
            ViewBag.productId = values.productID;
            ViewBag.title1 = values.title.ToString();
            ViewBag.price=values.price;
            ViewBag.city=values.city;
            ViewBag.district = values.district;
            ViewBag.address = values.address;
            ViewBag.type = values.type;
            ViewBag.description = values.description;
            ViewBag.date=values.advertisementDate;
           

            ViewBag.datediff =(((DateTime.Now.Month)-(values.advertisementDate.Month)) +12*( (DateTime.Now.Year)- (values.advertisementDate.Year)));

            
            ViewBag.bathCount = values2.BathCount;
            ViewBag.bedRoomCount= values2.BedRoomCount;
            ViewBag.size = values2.ProductSize;
            ViewBag.roomCount=values2.RoomCount;
            ViewBag.garageCount=values2.GarageSize;
            ViewBag.buildYear=values2.BuildYear;
            ViewBag.location=values2.Location;
            ViewBag.videoUrl=values2.VideoUrl;
            return View(values);
            
         
            
        }
    }
}
