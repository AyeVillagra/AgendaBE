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

            return Ok(_userRepository.GetAll());

        }
        [HttpGet]
        [Route("GetOne/{Id}")]
        public IActionResult GetOneById(int Id)
        {
            List<User> usersToReturn = _userRepository.GetAll();
            usersToReturn.Where(x => x.Id == Id).ToList();
            if (usersToReturn.Count > 0)
                return Ok(usersToReturn);
            return NotFound("usuario inexistente");

        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (_userRepository.GetById(id).Name == "Admin")
                {
                    _userRepository.Delete(id);
                }
                else
                {
                    _userRepository.Archive(id);
                }
                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }

}

