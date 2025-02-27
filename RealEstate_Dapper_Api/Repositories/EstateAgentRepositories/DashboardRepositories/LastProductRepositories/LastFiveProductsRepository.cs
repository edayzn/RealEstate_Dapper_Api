using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories
{
    public class LastFiveProductsRepository : ILastFiveProductsRepository
    {
        private readonly Context _context;

        public LastFiveProductsRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductAsync(int id)
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where AppUserId=@appUserId Order By ProductID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLastFiveProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
