using AngASPNETCOREBackend.Dtos;
using AngASPNETCOREBackend.Models;
using AngASPNETCOREBackend.Models.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepositoryInterface _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepositoryInterface userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //GET /api/users/number
        [HttpGet]
        [Route("number")]
        public ActionResult<int> GetNumberOfUsers()
        {
            return _userRepository.GetNumberOfUsers;
        }

        //GET /api/users
        [HttpGet]
        public ActionResult<IEnumerable<UsersReadDto>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers.ToList();
            return Ok(_mapper.Map<IEnumerable<UsersReadDto>>(users));
        }


        //GET /api/users/id
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UsersReadDto> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if(user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<UsersReadDto>(user)) ;
            }
        }

        //POST /api/users
        [HttpPost]
        public ActionResult<UsersReadDto> CreateUser(UsersCreateDto userToCreate)
        {
            var usersModel = _mapper.Map<Users>(userToCreate);
            _userRepository.CreateUser(usersModel);

            var usersReadDto = _mapper.Map<UsersReadDto>(usersModel);

            return CreatedAtRoute(nameof(GetUserById), new  { Id = usersReadDto.Id}, usersReadDto);
        }

        //PUT /api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, UsersUpdateDto usersUpdateDto)
        {
            var userToBeUpdated = _userRepository.GetUserById(id);
            if(userToBeUpdated == null)
            {
                return NotFound();
            }

            _mapper.Map(usersUpdateDto, userToBeUpdated);
            _userRepository.UpdateUser(userToBeUpdated);

            return NoContent();
        }

        //DELETE /api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var userToBeDeleted = _userRepository.GetUserById(id);

            if (userToBeDeleted == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(userToBeDeleted);

            return NoContent();
        }

            
           
    }
}
