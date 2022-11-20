using apidemo.Data.Repository;
using apidemo.Data.Repository.Interfaces;
using apidemo.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace apidemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        //private readonly IMapper _autoMapper;

        public UserController(IUserRepository userRepository)
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
            try
            {
                return Ok(_userRepository.GetById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userRepository.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userRepository.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }


    }

}

