using apidemo.Data.Repository;
using apidemo.DTOs;
using apidemo.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace apidemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private UserRepository _userRepository { get; set; }
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {

            return Ok(_userRepository.GetAllUsers());

        }
        [HttpGet]
        [Route("GetOne/{Id}")]
        public IActionResult GetOneById(int Id)
        {
            List<User> usersToReturn = _userRepository.GetAllUsers();
            usersToReturn.Where(x => x.Id == Id).ToList();
            if (usersToReturn.Count > 0)
                return Ok(usersToReturn);
            return NotFound("usuario inexistente");

        }

        
    }

}

