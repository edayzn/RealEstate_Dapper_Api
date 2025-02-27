using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }
        public int AllProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public int  ProductCountByEmployeeId(int id)
        {
            string query = "Select Count(*) From Product Where AppUserId=@appUserId";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
           
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query,parameters);
                return values;
            };
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = "Select Count(*) From Product Where AppUserId=@appUserId and ProductStatus=0;";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);

            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query, parameters);
                return values;
            };
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = "Select Count(*) From Product Where AppUserId=@appUserId and ProductStatus=1;";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);

            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query, parameters);
                return values;
            };
        }
    }
}
