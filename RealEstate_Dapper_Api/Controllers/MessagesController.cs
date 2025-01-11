using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetInBoxLastThreeMessageListByReceiver(int id) 
        {
            var values=await _messageRepository.GetInBoxLastThreeMessageListByReceiver(id);
            return Ok(values);
        }
    }
}
