using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductImageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepositores
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int id)
        {
            string query = "Select * From ProductImage where ProductID=@ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryAsync<GetProductImageByProductIdDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
