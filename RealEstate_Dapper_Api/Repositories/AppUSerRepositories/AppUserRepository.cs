using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUSerRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetAppUserByProductIdDto> GetAppUSerByPRoductId(int id)
        {
            string query = "Select * From AppUser where UserId=@UserId";
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return values;
            }
        }
    }
}
