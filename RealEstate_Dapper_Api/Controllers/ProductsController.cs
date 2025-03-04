﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values=await _productRepository.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
         await _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatlarına Eklendi.");
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
          await _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatlarından Çıkarıldı.");
        }
        [HttpGet("LastProductFiveList")]
        public async Task<IActionResult> LastProductFiveList()
        {
            var values = await _productRepository.GetLastFiveProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertsListByEmployeeByTrueAsync(id);
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertsListByEmployeeByFalseAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("ilan başarıyla yüklendi");
        }
        [HttpGet("GetProductByProductId")]
        public async Task<IActionResult> GetProductByProductId(int id)
        {
           var values= await _productRepository.GetProductByProductId(id);
            return Ok(values);
        }
        [HttpGet("ResultProductWithSearchListDto")]
        public async Task<IActionResult> ResultProductWithSearchListDto(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values = await _productRepository.ResultProductWithSearchListDto(searchKeyValue,propertyCategoryId,city);
            return Ok(values);
        }

        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("GetLastThreeProductAsync")]
        public async Task<IActionResult> GetLastThreeProduct()
        {
            var values = await _productRepository.GetLastThreeProductAsync();
            return Ok(values);
        }
        [HttpGet("GetProductIdByAppUser")]
        public async Task<IActionResult> GetProductIdByAppUser(int id)
        {
            var values = await _productRepository.GetProductIdByAppUser(id);
            return Ok(values);
        }
    }

}
