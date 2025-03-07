﻿
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeByTrueAsync(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeByFalseAsync(int id);
        Task<List<ResultProductWithCategoryDto>>GetAllProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<GetProductIdByAppUserDto>> GetProductIdByAppUser(int id);

        Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductAsync();
        Task<List<ResultLastThreeProductWithCategoryDto>> GetLastThreeProductAsync();

        Task CreateProduct(CreateProductDto createProductDto);
    
        Task<GetProductByProductIdDto> GetProductByProductId(int id);
        Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id);

        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchListDto(string searchKeyValue, int propertyCategoryId, string city);
        Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync();
    }
}
