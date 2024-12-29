using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductsController : ControllerBase
    {
        private readonly ILastFiveProductsRepository _lastProdycRepository;
public EstateAgentLastProductsController(ILastFiveProductsRepository lastProdycRepository)
        {
            _lastProdycRepository = lastProdycRepository;
        }
        [HttpGet]
        public async Task< IActionResult> GetLastFiveProductAsync(int id) {
            var values=await _lastProdycRepository.GetLastFiveProductAsync(id);
            return Ok(values);

        }
    }
}
