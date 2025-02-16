using Dapper;
using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepositories
{
    public class SubFeatureRepository : ISubFeatureRepository
    {

        private readonly Context _context;

        public SubFeatureRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
        {
            string query = " Select * From SubFeature";
            using (var conncetion = _context.CreateConnection())
            {

                //Dapper kısmı
                var values = await conncetion.QueryAsync<ResultSubFeatureDto>(query);
                return values.ToList();
            }
        }
    }
}
