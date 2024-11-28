using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = " Select * From Product";
            using (var conncetion = _context.CreateConnection())
            {


                var values = await conncetion.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = " Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var conncetion = _context.CreateConnection())
            {
                var values = await conncetion.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductAsync()
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate  From Product inner Join Category On Product.ProductCategory=Category.CategoryID Where Type='Kiralık' Order By ProductID Desc";
            using (var conncetion = _context.CreateConnection())
            {


                var values = await conncetion.QueryAsync<ResultLastFiveProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeAsync(int id)
        {
            string query = " Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeId=@employeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var conncetion = _context.CreateConnection())
            {
                var values = await conncetion.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query,parameters);
                return values.ToList();
            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            {
                string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";

                var parameters = new DynamicParameters();
                parameters.Add("@productID", id);

                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }

        }
        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            {
                string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";

                var parameters = new DynamicParameters();
                parameters.Add("@productID", id);

                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
        }
    }
}
