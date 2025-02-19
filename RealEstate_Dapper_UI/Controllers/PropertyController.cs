using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public PropertyController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            //n istemci örneği
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
            var responseMassage = await client.GetAsync("Products/ProductListWithCategory");


            if (responseMassage.IsSuccessStatusCode)
            {
                var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
         public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
			ViewBag.searchKeyValue = TempData["searchKeyValue"];
			ViewBag.propertyCategoryId = TempData["propertyCategoryId"];
			ViewBag.city = TempData["city"];

            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
            var responseMassage = await client.GetAsync($"Products/ResultProductWithSearchListDto?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");


            if (responseMassage.IsSuccessStatusCode)
            {
                var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug, int id)
        {
            ViewBag.i = id;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiSettings.BaseUrl);
            var responseMassage = await client.GetAsync("Products/GetProductByProductId?id="+id);

            var jsonData = await responseMassage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

            var responseMassage2 = await client.GetAsync("ProductDetails/GetProductDetailByProductId?id=" + id);
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
            ViewBag.userId = values.appUserId;
            
            //ViewBag.slugUrl = values.SlugUrl;
           

            ViewBag.datediff =(((DateTime.Now.Month)-(values.advertisementDate.Month)) +12*( (DateTime.Now.Year)- (values.advertisementDate.Year)));

            
            ViewBag.productIdToPtoductDetail = values2.ProductId;
            ViewBag.bathCount = values2.BathCount;
            ViewBag.bedRoomCount= values2.BedRoomCount;
            ViewBag.size = values2.ProductSize;
            ViewBag.roomCount=values2.RoomCount;
            ViewBag.garageCount=values2.GarageSize;
            ViewBag.buildYear=values2.BuildYear;
            ViewBag.location=values2.Location;
            ViewBag.videoUrl=values2.VideoUrl;

            string slugFromTitle = CreateSlug(values.title);
            ViewBag.slugUrl = slugFromTitle;


            return View();
            
        }
        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

            return title;
        }
    }
}
