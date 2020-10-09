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
        public async Task<ActionResult<int>> GetNumberOfUsers()
        {
            return await _userRepository.GetNumberOfUsers();
        }

        //GET /api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersReadDto>>> GetAllUsers()
        {
          


            var users = await _userRepository.GetAllUsers();
            if (users != null)
            {
                return  Ok(_mapper.Map<IEnumerable<UsersReadDto>>(users));

            }
            else
            {
                return NotFound();
            }

         
        }


        //GET /api/users/id
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UsersReadDto>> GetUserById(int id)
        {
            var user =  await _userRepository.GetUserById(id);

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
        public async Task<ActionResult<UsersReadDto>> CreateUser(UsersCreateDto userToCreate)
        {
            var usersModel = _mapper.Map<Users>(userToCreate);
            await _userRepository.CreateUser(usersModel);

            var usersReadDto = _mapper.Map<UsersReadDto>(usersModel);

            return CreatedAtRoute(nameof(GetUserById), new  { Id = usersReadDto.Id}, usersReadDto);
        }

        //PUT /api/users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, UsersUpdateDto usersUpdateDto)
        {
            var userToBeUpdated = await _userRepository.GetUserById(id);
            if(userToBeUpdated == null)
            {
                return NotFound();
            }

            _mapper.Map(usersUpdateDto, userToBeUpdated);
            await _userRepository.UpdateUser(userToBeUpdated);

            return NoContent();
        }

        //DELETE /api/users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            var userToBeDeleted = await _userRepository.GetUserById(id);

            if (userToBeDeleted == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUser(userToBeDeleted);

            return NoContent();
        }

            
           
    }
}
