using apidemo.Data.Repository.Interfaces;
using apidemo.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace apidemo.Controllers
{
    [Route("api/[controller]")] //[controller] indica que la ruta es /el nombre del controlador. En //
    //este caso, /contact
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private IContactRepository _contactRepository;
        private IUserRepository _userRepository;


        public ContactController(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;

        }

        [HttpGet] 
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_contactRepository.GetAll());
        }
        [HttpGet]
        [Route("GetOne/{Id}")]
        public IActionResult GetOneById(int Id)
        {
            return Ok(_contactRepository.GetAll().Where(x => x.Id == Id).ToList());

        }

        [HttpPost]
        public IActionResult CreateContact(CreateAndUpdateContact createContactDto)
        {
            try
            {
                _contactRepository.Create(createContactDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", createContactDto);
        }

        [HttpPut]
        public IActionResult UpdateContact(CreateAndUpdateContact dto)
        {
            try
            {
                _contactRepository.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
                    if (role.Value == "Admin")
                                    
                // if(HttpContext.User.) es el lugar donde Microsoft guarda el Token cuando lo recibe
                // HttpContext.User.Identity devuelve el Id del usuario (no sabe el tipo de dato)
                
                {
                    _userRepository.Delete(id);
                    
                }
                else
                {
                    _userRepository.Archive(id);                   
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

 



    }
}
