using AngASPNETCOREBackend.Models;
using AngASPNETCOREBackend.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Controllers
{
    [ApiController]
    [Route("api/conversations")]
    public class ConversationsController : ControllerBase
    {

        private readonly IConversationsRepository _userRepository;
        public ConversationsController(IConversationsRepository userRepoistory)
        {
            _userRepository = userRepoistory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conversations>>> GetAllConversations()
        {
            var convers = await _userRepository.GetAllConversations();
            foreach(var conv in convers)
            {
                Console.WriteLine("salut");
            }
            return Ok(convers); 
        }



    }
}
