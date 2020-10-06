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
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepositoryInterface _userRepository;
        public UsersController(IUsersRepositoryInterface userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("number")]
        public int GetNumberOfUsers()
        {
            return _userRepository.GetNumberOfUsers;
        }

        [HttpGet]
        public List<Users> GetAllUsers()
        {
            //return _userRepository.GetAllUsers.ToList();
            /*
            List<Users> _users = new List<Users>();

            _users.Add(new Users("name", "pass", "sal"));
            _users.Add(new Users("2", "sda", "fasf"));


            return _users;
            */
            return _userRepository.GetAllUsers.ToList();
        }

    }
}
