using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }


        [HttpPost]

        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "Select*From AppUser Where Username=@username and Password=@password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", loginDto.Username);
            parameters.Add("@password", loginDto.Password);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserWithUserIdDto>(query, parameters);
                if (values != null)
                {
                    GetCheckAppUserViewModel model= new GetCheckAppUserViewModel();
                    model.Username = values.Username;
                    model.Id = values.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);

                        
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
