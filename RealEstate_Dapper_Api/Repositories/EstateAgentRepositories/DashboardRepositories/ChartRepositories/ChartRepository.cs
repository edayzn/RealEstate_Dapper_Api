using Dapper;
using RealEstate_Dapper_Api.Dtos.ChartDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task< List<ResultChartDto>> GetFiveCityForChart()
        {

            string query = " Select top (5) City,Count(*) as 'CityCount' From Product Group By City order By CityCount Desc";
            using (var conncetion = _context.CreateConnection())
            {

                //Dapper kısmı
                var values = await conncetion.QueryAsync<ResultChartDto>(query);
                return values.ToList();
            }
        }
    }
}
